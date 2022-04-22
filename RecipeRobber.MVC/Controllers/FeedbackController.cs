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
    [Authorize]
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

        public ActionResult Create()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackCreate model)
        {

            if (!ModelState.IsValid) return View(model);


            var service = CreateFeedbackService();

            if (service.CreateFeedback(model))
            {
                TempData["SaveResult"] = "Your Feedback was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Feedback not created.");

            return View(model);

        }
        private FeedbackService CreateFeedbackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeedbackService(userId);
            return service;
        }
        public ActionResult Delete(int id)
        {
            var service = CreateFeedbackService();
            var model = service.GetFeedbackById(id);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateFeedbackService();
            var model = service.GetFeedbackById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeedback(int id)
        {
            var service = CreateFeedbackService();

            if (service.DeleteFeedback(id))
            {
                TempData["SaveResult"] = "Feedback is deleted.";
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}