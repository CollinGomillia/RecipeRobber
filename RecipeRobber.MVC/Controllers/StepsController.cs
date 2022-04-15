using Microsoft.AspNet.Identity;
using RecipeRobber.Models.StepModels;
using RecipeRobber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeRobber.MVC.Controllers
{
    [Authorize]
    public class StepsController : Controller
    {
        // GET: Steps
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StepService(userId);
            var model = service.GetSteps();
            return View(model);
        }

        //CREATE
        public ActionResult Create()
        {
            
            return View();
        }

        private StepService StepCreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StepService(userId);
            return service;
        }

        //CREATE STEP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStep(StepCreate model)
        {
            var service = StepCreateService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateSteps(model))
            {
                TempData["SaveResult"] = "Your step was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        

        //Update Step
        public ActionResult Update(int id, StepUpdate model)
        {
            var service = StepCreateService();

            

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.StepId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (service.UpdateSteps(model))
            {
                TempData["SaveResult"] = "Step was changed.";
                return RedirectToAction("Index");
            }


            return View(model);
        }

        public ActionResult Update(int id)
        {
            var service = StepCreateService();
            var detail = service.GetStepById(id);
            var model = new StepUpdate
            {
                StepId = detail.StepId,
                Instruction = detail.Instruction,

            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = StepCreateService();
            var model = service.GetStepById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStep(int id)
        {
            var service = StepCreateService();

            service.DeleteStep(id);
            
            TempData["SaveResult"] = "Step was deleted";

            return RedirectToAction("Index");
           
        }
    }
}