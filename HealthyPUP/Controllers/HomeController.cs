using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyPUP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyPUP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Dog dog)
        {
            if (dog == null)
                return View("~/Areas/Identity/Account/Login");
            else
            return RedirectToAction("Index", "Dog");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
