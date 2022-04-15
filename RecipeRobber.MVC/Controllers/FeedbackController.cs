using Microsoft.AspNet.Identity;
using RecipeRobber.Models.FeedbackModels;
using RecipeRobber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeRobber.MVC.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeedbackService(userId);
            var model = service.GetFeedbacks();

            return View(model);
            
        }

        //Get feedback
        public ActionResult Comment(int id)
        {
            var service = CreateFeedbackService();

            var model = service.GetCommentById(id);

            return View(model);

        }
        private FeedbackService CreateFeedbackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeedbackService(userId);
            return service;
        }

        //Post feedback
        [HttpPost, ActionName("Comment")]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(FeedbackCreate model)
        {
            var service = CreateFeedbackService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Comment added";
                return RedirectToAction("Comment", model.RecipeId);
            }

            return View(model);
        }
        //Delete feedback //Helper
        public ActionResult FeedbackDelete(int id)
        {
            var feedService = CreateFeedbackService();

            var comment = feedService.GetCommentById(id);

            var viewModel = new FeedbackGet
            {
                Comment = comment.Comment,
                AuthorId = comment.AuthorId,
                RecipeId = comment.RecipeId,
                Rating = comment.Rating
            };

            return View(viewModel);
        }
        //Delete feedback
        [HttpPost, ActionName("FeedbackDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeedback(int id)
        {
            var service = CreateFeedbackService();

            if (service.DeleteComment(id))
            {
                TempData["SaveResult"] = "Feedback deleted";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}