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

        //CREATE recipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
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
        //Helper
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
                MakeTime = detail.MakeTime
               
            };

            return View(model);
        }
        //Recipe update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeUpdate model)
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
        
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        //Delete Recipe
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "Your recipe was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var service = CreateRecipeService();
            var model = service.GetRecipeById(id);

            return View(model);
        }


    }
}