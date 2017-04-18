using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfaces.Services;

namespace NewsWebsite.Controllers
{
    public class NavController : Controller
    {
        private readonly ICategoryService categoryService;

        public NavController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = categoryService.GetAll()
                .Select(x => x.Name)
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}