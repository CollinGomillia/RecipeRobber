using Microsoft.AspNet.Identity;
using RecipeRobber.Models.IngredientModels;
using RecipeRobber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeRobber.MVC.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            var model = service.GetIngredients();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            var service = CreateIngredientService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult IngredientGet(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }
        public ActionResult IngredientUpdate(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientUpdate
                {
                    Ingredients = detail.Ingredients,
                    Measurement = detail.Measurement,
                    CustomaryUnit = detail.CustomaryUnit
                    
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientUpdate model)
        {
            var service = CreateIngredientService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.IngredientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "Ingredient(s) was changed.";
                return RedirectToAction("Index");
            }


            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateIngredientService();
            var model = service.GetIngredientById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateIngredientService();

            if (service.DeleteIngredient(id))
            {
                TempData["SaveResult"] = "Goodbye, Ingredients!";
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}