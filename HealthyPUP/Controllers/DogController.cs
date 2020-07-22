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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HealthyPUP.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s
        public int PageSize = 4;
        private IDogRepository repository;
        private readonly IWebHostEnvironment webHostEnvironment;


        // C o n s t r u c t o r s
        public DogController (IDogRepository repository, IWebHostEnvironment hostEnvironment)
        {
            this.repository = repository;
            webHostEnvironment = hostEnvironment; 
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Dog dog, IFormFile file)
        {
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = System.IO.File.Create(filePath)) //creating a new file
                {
                    await file.CopyToAsync(stream); //streaming bits over putting into new path
                }
                dog.ProfilePicture = uniqueFileName;
            }

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
        public async Task<IActionResult> Update(Dog dog, IFormFile file)
        {
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = System.IO.File.Create(filePath)) //creating a new file
                {
                    await file.CopyToAsync(stream); //streaming bits over putting into new path
                }
                dog.ProfilePicture = uniqueFileName;
            }

            Dog d2 = repository.UpdateDog(dog);
            return RedirectToAction("Detail", "Dog", new { id = dog.Id });
            //Dog d = repository.Create(dog);

            //return RedirectToAction("Detail", "Dog", new { id = dog.Id });
        }
        //)
        //{
        //    Dog d2 = repository.UpdateDog(d);
        //    return RedirectToAction("Detail", "Dog", new { id = d.Id });
        //}

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
