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
        public IActionResult Index(string start, string end)
        {
            
            if (Int32.TryParse(start, out int startYear) && Int32.TryParse(end, out int endYear))
            {
                return RedirectToAction("Results", new { startYear, endYear });
            } else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Results(int start, int end)
        {
            return View(TimePerson.GetPeople(start, end));
        }
    }
}
