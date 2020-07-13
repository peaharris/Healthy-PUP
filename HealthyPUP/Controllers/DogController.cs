using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthyPUP.Models;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace HealthyPUP.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s
        public int PageSize = 4;
        private IDogRepository repository;

        // C o n s t r u c t o r s
        public DogController (IDogRepository repository)
        {
            this.repository = repository;
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dog dog)
        {
            Dog d = repository.Create(dog);
            return RedirectToAction("Detail", "Dog", new { id = dog.Id });
        }

        // R e a d
        public IActionResult Index()
        {
            IQueryable<Dog> allDogs =
                this.repository.GetAllDogs();
            return View(allDogs);
        }

        //public IActionResult Index(int dogPage=1)
        //{
        //    IQueryable<Dog> someDogs = repository.GetAllDogs()
        //        .OrderBy(d => d.Id)
        //        .Skip((dogPage - 1) * PageSize)
        //        .Take(PageSize);
        //    return View(someDogs);
        //}

        public IActionResult Detail(int id)
        {
            Dog d = repository.GetDogById(id);
            if (d != null)
            {
                return View(d);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string id)
        {
            IQueryable<Dog> dogs =
                repository.GetDogsByKeyword(id);
            return View(dogs);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // U p d a t e
        [HttpGet]
        public IActionResult Update(int id)
        {
            Dog d = repository.GetDogById(id);
            if (d != null)
            {
                return View(d);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(Dog d)
        {
            Dog d2 = repository.UpdateDog(d);
            return RedirectToAction("Detail", "Dog", new { id = d.Id });
        }

        // D e l e t e
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Dog dog = repository.GetDogById(id);
            if (dog != null)
            {
                return View(dog);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Dog dog)
        {
            repository.DeleteDog(dog.Id);
            return RedirectToAction("Index");
        }
    }
}
