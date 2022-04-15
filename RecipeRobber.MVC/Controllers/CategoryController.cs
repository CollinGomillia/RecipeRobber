using Microsoft.AspNet.Identity;
using RecipeRobber.Models.CategoryModels;
using RecipeRobber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeRobber.MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetCategories();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryCreate model)
        {
            var service = CreateCategoryService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "New category added.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            var model = service.GetCategoryById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var service = CreateCategoryService();

            if (service.DeleteCategory(id))
            {
                TempData["SaveResult"] = "Category is deleted.";
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}