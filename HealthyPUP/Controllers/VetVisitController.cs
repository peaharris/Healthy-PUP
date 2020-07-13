using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyPUP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyPUP.Controllers
{
    public class VetVisitController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s
        private IVetVisitRepository repository;

        // C o n s t r u c t o r s
        public VetVisitController(IVetVisitRepository repository)
        {
            this.repository = repository;
        }

        // M e t h o d s - C R U D
        // C r e a t e
        [HttpGet]
        public IActionResult Create(int id) //this is the vet visit id
        {
            VetVisit v = new VetVisit();
            v.DogId = id;
            return View(v);
        }
        [HttpPost]
        public IActionResult Create(VetVisit v)
        {
            v.Id = 0; //Hack / fix
            repository.Create(v);
            return RedirectToAction("Detail", "Dog", new { id = v.DogId });
        }
        // R e a d 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            VetVisit vetVisit = repository.GetVetVisitById(id);
            return View(vetVisit);
        }
        // U p d a t e
        [HttpGet]
        public IActionResult Update(int id)
        {
            VetVisit v = repository.GetVetVisitById(id);
            if (v != null)
            {
                return View(v);
            }
            return RedirectToAction("Detail", "Dog");
        }
        [HttpPost]
        public IActionResult Update(VetVisit v)
        {
            VetVisit v2 = repository.UpdateVetVisit(v);
            return RedirectToAction("Detail", "Dog", new { id = v.DogId });
        }
        // D e l e t e
        [HttpGet]
        public IActionResult Delete(int id)
        {
            VetVisit vetVisit = repository.GetVetVisitById(id);
            return View(vetVisit);
        }
        [HttpPost]
        public IActionResult Delete(VetVisit v)
        {
            repository.DeleteVetVisit(v.Id);
            return RedirectToAction("Detail", "Dog", new { id = v.DogId });

        }
    }
}
