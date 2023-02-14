using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6_mitch921.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_mitch921.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext moviesContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MoviesContext x)
        {
            _logger = logger;
            moviesContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(MovieEntry me)
        {
            moviesContext.Add(me);
            moviesContext.SaveChanges();

            return View("Confirmation", me);
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
    }
}
