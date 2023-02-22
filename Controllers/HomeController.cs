using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MoviesContext moviesContext { get; set; }

        //Constructor
        public HomeController(MoviesContext x)
        {
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
            ViewBag.Categories = moviesContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(MovieEntry me)
        {
            if (ModelState.IsValid)
            {
                moviesContext.Add(me);
                moviesContext.SaveChanges();

                return View("Confirmation", me);
            }
            else
            {
                ViewBag.Categories = moviesContext.Categories.ToList();
                return View(me);
            }
        }

        public IActionResult MovieList()
        {
            var movies = moviesContext.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = moviesContext.Categories.ToList();

            var movie = moviesContext.Movies.Single(x => x.MovieID == movieid);

            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry me)
        {
            moviesContext.Update(me);
            moviesContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = moviesContext.Movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry me)
        {
            moviesContext.Movies.Remove(me);
            moviesContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
