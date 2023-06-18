using Microsoft.AspNetCore.Mvc;
using Online_Movie.Models;
using Online_Movie.Models.Authentication;
using Online_Movie.Repository;
using System.Collections.Generic;
using System.Diagnostics;

namespace Online_Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieReposistory _movieReposistory;

        public HomeController(ILogger<HomeController> logger, IMovieReposistory movieReposistory)
        {
            _logger = logger;
            _movieReposistory = movieReposistory;
        }

        public IActionResult findMoviesByCategoryId(int id)
        {
            List<Movie> Movie = _movieReposistory.GetAllMoviesByCategoryId(id);
            return View(Movie);
        }

		public IActionResult ViewMovieDetail(int id)
        {
            Movie c = _movieReposistory.findByID(id);
            return View(c);
		}
		public IActionResult ViewAllMovies()
        {
            List<Movie> movies = _movieReposistory.GetAll();
            return View(movies);
        }
        
        public IActionResult Index()
        {
            List<Movie> movies = _movieReposistory.GetAll();
			return View(movies);
        }
        [Authentication]
        public IActionResult Ticket_Booking()
		{
			return View();
		}
		public IActionResult About()
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