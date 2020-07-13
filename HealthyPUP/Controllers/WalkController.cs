using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyPUP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyPUP.Controllers
{
    public class WalkController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s
        private IWalkRepository repository;

        // C o n s t r u c t o r s
        public WalkController(IWalkRepository repository)
        {
            this.repository = repository;
        }

        // M e t h o d s - C R U D
        // C r e a t e
        [HttpGet]
        public IActionResult Create(int id) //this is the walk id
        {
            Walk w = new Walk();
            w.DogId = id;
            return View(w);
        }
        [HttpPost]
        public IActionResult Create(Walk w)
        {
            w.Id = 0; //Hack / fix
            repository.Create(w);
            return RedirectToAction("Detail", "Dog", new { id = w.DogId });
        }
        // R e a d 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            Walk walk = repository.GetWalkById(id);
            return View(walk);
        }
        // U p d a t e
        [HttpGet]
        public IActionResult Update(int id)
        {
            Walk w = repository.GetWalkById(id);
            if (w != null)
            {
                return View(w);
            }
            return RedirectToAction("Detail", "Dog");
        }
        [HttpPost]
        public IActionResult Update(Walk w)
        {
            Walk w2 = repository.UpdateWalk(w);
            return RedirectToAction("Detail", "Dog", new { id = w.DogId });
        }
        // D e l e t e
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Walk walk = repository.GetWalkById(id);
            return View(walk);
        }
        [HttpPost]
        public IActionResult Delete(Walk w)
        {
            repository.DeleteWalk(w.Id);
            return RedirectToAction("Detail", "Dog", new { id = w.DogId });

        }
    }
}
