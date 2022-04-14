using Microsoft.AspNet.Identity;
using RecipeRobber.Models.FeedbackModels;
using RecipeRobber.Models.RecipeModels;
using RecipeRobber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RecipeRobber.MVC.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecipe(RecipeCreate model)
        {
            var service = CreateRecipeService();

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "This recipe couldn't be created.");

            return View(model);
        }
        
        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }

        //EDIT Recipe

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();

            var detail = service.GetRecipeById(id);

            var model = new RecipeUpdate
            {
                RecipeId = detail.RecipeId,
                RecipeName = detail.RecipeName,
                ModifiedAt = detail.ModifiedAt,
                CreatedAt = detail.CreatedAt,
                MakeTime = detail.MakeTime
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecipeEdit(int id, RecipeUpdate model)
        {
            var service = CreateRecipeService();

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            
            if(service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "Your recipe was deleted";

            return RedirectToAction("Index");
        }

        //Get feedback
        public ActionResult Comment(int id)
        {
            var service = CreateRecipeService();

            var view = new FeedbackCreate();

            view.RecipeGet = service.GetRecipeById(id);
            view.RecipeId = id;

            return View(view);

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
        //Delete feedback
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