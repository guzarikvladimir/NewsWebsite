using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using NewsWebsite.Models;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace NewsWebsite.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;

        public CommentsController(ICommentService commentService, IUserService userService)
        {
            this.commentService = commentService;
            this.userService = userService;
        }

        public ActionResult Create(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetAll().FirstOrDefault(u => u.Login == User.Identity.Name);
                commentService.Create(new CommentEntity()
                {
                    CreationDate = DateTime.Now,
                    CreationTime = DateTime.Now.TimeOfDay,
                    Name = comment.Name,
                    NewId = comment.NewsId,
                    UserId = user.Id
                });
                if (Request.IsAjaxRequest())
                {
                    var comments = commentService.GetAll()
                        .Where(com => com.NewId == comment.NewsId)
                        .OrderByDescending(com => com.CreationDate)
                        .ThenByDescending(com => com.CreationTime).ToList();
                    return PartialView("_Comments", comments);
                }
            }
            return RedirectToAction("About", "Home", comment.NewsId);
        }

        public ActionResult Delete(int commentId, int newsId)
        {
            commentService.Delete(commentId);
            if (Request.IsAjaxRequest())
            {
                var comments = commentService.GetAll()
                        .Where(com => com.NewId == newsId)
                        .OrderByDescending(com => com.CreationDate)
                        .ThenByDescending(com => com.CreationTime).ToList();
                return PartialView("_Comments", comments);
            }
            return RedirectToAction("About", "Home", newsId);
        }
    }
}