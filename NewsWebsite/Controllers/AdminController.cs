using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace NewsWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly INewsService newsService;
        private readonly ICategoryService categoryService;

        public AdminController(INewsService newsService, ICategoryService categoryService)
        {
            this.newsService = newsService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View(newsService.GetAll()
                .OrderByDescending(x => x.CreationDate)
                .ThenByDescending(x => x.CreationTime)
                .AsNoTracking().ToList());
        }

        public ActionResult Edit(int newsId)
        {
            var news = newsService.GetAll()
                .FirstOrDefault(n => n.Id == newsId);
            news.Category = string.Empty;
            ViewBag.Categories = GetCategories();
            return View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsEntity news, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    news.ImageMimeType = image.ContentType;
                    using (var binaryReader = new BinaryReader(image.InputStream))
                    {
                        news.ImageData = binaryReader.ReadBytes(image.ContentLength);
                    }
                }
                if (news.Category != null)
                {
                    categoryService.Create(new CategoryEntity() { Name = news.Category });
                    news.CategoryId = categoryService.GetAll().FirstOrDefault(c => c.Name == news.Category).Id;
                }
                if (news.Id != 0)
                {
                    newsService.Update(news);
                }
                else
                {
                    newsService.Create(news);
                }
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View("Edit", new NewsEntity());
        }

        public ActionResult Delete(int newsId)
        {
            var news = newsService.GetAll().FirstOrDefault(n => n.Id == newsId);
            var categoryCount = newsService.GetAll()
                .Count(x => x.CategoryId == news.CategoryId);
            if (categoryCount == 1)
            {
                categoryService.Delete(news.CategoryId);
            }
            else
            {
                newsService.Delete(newsId);
            }
            return RedirectToAction("Index");
        }

        public SelectList GetCategories()
        {
            return new SelectList(categoryService.GetAll().AsNoTracking().ToList(), "Id", "Name");
        }
    }
}