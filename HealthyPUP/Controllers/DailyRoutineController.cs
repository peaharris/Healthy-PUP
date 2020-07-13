using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyPUP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyPUP.Controllers
{
    public class DailyRoutineController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s
        private IDailyRoutineRepository repository;

        // C o n s t r u c t o r s
        public DailyRoutineController(IDailyRoutineRepository repository)
        {
            this.repository = repository;
        }

        // M e t h o d s - C R U D
        // C r e a t e
        [HttpGet]
        public IActionResult Create(int id) //this is the vet visit id
        {
            DailyRoutine dr = new DailyRoutine();
            dr.DogId = id;
            return View(dr);
        }
        [HttpPost]
        public IActionResult Create(DailyRoutine dr)
        {
            dr.Id = 0; //Hack / fix
            repository.Create(dr);
            return RedirectToAction("Detail", "Dog", new { id = dr.DogId });
        }
        // R e a d 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            DailyRoutine dailyRoutine = repository.GetDailyRoutineById(id);
            return View(dailyRoutine);
        }
        // U p d a t e
        [HttpGet]
        public IActionResult Update(int id)
        {
            DailyRoutine dr = repository.GetDailyRoutineById(id);
            if (dr != null)
            {
                return View(dr);
            }
            return RedirectToAction("Detail", "Dog");
        }
        [HttpPost]
        public IActionResult Update(DailyRoutine dr)
        {
            DailyRoutine dr2 = repository.UpdateDailyRoutine(dr);
            return RedirectToAction("Detail", "Dog", new { id = dr.DogId });
        }
        // D e l e t e
        [HttpGet]
        public IActionResult Delete(int id)
        {
            DailyRoutine dailyRoutine = repository.GetDailyRoutineById(id);
            return View(dailyRoutine);
        }
        [HttpPost]
        public IActionResult Delete(DailyRoutine dr)
        {
            repository.DeleteDailyRoutine(dr.Id);
            return RedirectToAction("Detail", "Dog", new { id = dr.DogId });

        }
    }
}
