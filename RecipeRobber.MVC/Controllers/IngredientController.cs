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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {

            if (!ModelState.IsValid) return View(model);


            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category not created.");

            return View(model);

        }
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
        public ActionResult Delete(int id)
        {
            var service = CreateIngredientService();
            var model = service.GetIngredientById(id);

            return View(model);
        }

        public ActionResult Details(int id)
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
                TempData["SaveResult"] = "Ingredient is deleted.";
                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();

            var detail = service.GetIngredientById(id);

            var model = new IngredientUpdate
            {
               IngredientId = detail.IngredientId,
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

    }
}