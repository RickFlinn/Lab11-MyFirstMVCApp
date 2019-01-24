using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimePersonOfTheYear.Models;

namespace TimePersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int start, int end)
        {
            return RedirectToAction("Results", new { start, end });
        }

        public IActionResult Results(int start, int end)
        {
            return View(TimePerson.GetPeople(start, end));
        }
    }
}
