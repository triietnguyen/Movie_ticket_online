using Microsoft.AspNetCore.Mvc;
using Online_Movie.Models;
using Online_Movie.Repository;
using System.Diagnostics;

namespace Online_Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDAO movieDAO = new MovieDAO();
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

        public IActionResult ViewMovieDetails()
        {
            return View("ViewMovieDetails");
        }

        public IActionResult ViewAllMovies()
        {
            List<Movie> movies = movieDAO.getAllMovies();
            return View(movies);
        }
        public IActionResult Index()
        {
            List<Movie> movies = movieDAO.getAllMovies();
            return View(movies);
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