using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace NewsWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService newsService;
        private int pageSize = 24;
        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string category, int? page, string name = null)
        {
            int npage = page ?? 0;
            ViewBag.SelectedCategory = category;
            if (Request.IsAjaxRequest())
            {
                return PartialView("Items", GetItemsPage(category, npage, name));
            }
            return View(GetItemsPage(category, npage, name));
        }

        public ViewResult About(int newsId)
        {
            NewsEntity news = newsService.GetAll().FirstOrDefault(n => n.Id == newsId);
            return View(news);
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = newsService.GetAll().Where(x => x.Name.Contains(term))
                .ToList().Select(x => new { value = x.Name });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        private List<NewsEntity> GetItemsPage(string category, int page = 1, string name = null)
        {
            var itemsToSkip = page*pageSize;
            return newsService.GetAll()
                .Where(n => category == null || category == string.Empty 
                    ? n.Category != null : n.Category == category)
                .Where(x => name == null || name == string.Empty
                    ? x.Name != null : x.Name.Contains(name))
                .OrderByDescending(n => n.CreationDate)
                .ThenByDescending(n => n.CreationTime)
                .Skip(itemsToSkip).Take(pageSize)
                .ToList();
        }
    }
}