using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TimePersonOfTheYear.Models;

namespace TimePersonOfTheYear.Controllers
{
    public class HomeController : Controller

    {
        private string webRootPath;

        public HomeController(IHostingEnvironment env)
        {
            webRootPath = env.WebRootPath;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string startYear, string endYear)
        {
            
            if (Int32.TryParse(startYear, out int start) && Int32.TryParse(endYear, out int end))
            {
                return RedirectToAction("Results", new { start, end });
            } else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        public IActionResult Results(int start, int end)
        {
            return View(TimePerson.GetPeople(start, end, webRootPath));
        }
    }
}
