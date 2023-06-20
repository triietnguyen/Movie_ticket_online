using Microsoft.AspNetCore.Mvc;
using Online_Movie.Models;
using Online_Movie.Models.Authentication;
using Online_Movie.Repository;

namespace Online_Movie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private IMovieReposistory _movieReposistory;
        private ICategoryReposistory _categoryReposistory;

        public HomeController(IMovieReposistory movieReposistory, ICategoryReposistory categoryReposistory)
        {
            _movieReposistory = movieReposistory;
            _categoryReposistory = categoryReposistory;
        }
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                //check name in db
                bool isCategoryNameExist = _categoryReposistory.checkName(category.CategoryName);

                if (isCategoryNameExist)
                {
                    ModelState.AddModelError(string.Empty, "CategoryName is Exist!!!");
                    return View("CreateCategory");
                }
                else
                {
                    _categoryReposistory.Create(category);
                    return RedirectToAction("ViewAllCategories");
                }
            }
            else
            {
                return View("CreateCategory");
            }
        }

        [HttpPost]
        public IActionResult SaveMovie(Movie movie)
        {
            _movieReposistory.Create(movie);
            return RedirectToAction("ViewAllMovies");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View("CreateCategory", new Category());
        }
        
        [HttpGet]
        public IActionResult CreateMovie()
        {
            var q1 = from c in _categoryReposistory.GetAll()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.CategoryName,
                         Value = c.CategoryId.ToString(),
                     };
            ViewBag.CategoryId = q1.ToList();
            
            return View("CreateMovie", new Movie());
        }

        public IActionResult EditCategory(int id)
        {
            return View("EditCategory", _categoryReposistory.findByID(id));
        }

        public IActionResult EditMovie(int id)
        {
            var q1 = from c in _categoryReposistory.GetAll()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.CategoryName,
                         Value = c.CategoryId.ToString(),
                     };
            ViewBag.CategoryId = q1.ToList();
            return View("EditMovie", _movieReposistory.findByID(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryReposistory.Update(category);
            return RedirectToAction("ViewAllCategories");
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            _movieReposistory.Update(movie);
            return RedirectToAction("ViewAllMovies");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryReposistory.Delete(id);
            return RedirectToAction("ViewAllCategories");
        }

        public IActionResult DeleteMovie(int id)
        {
            _movieReposistory.Delete(id);
            return RedirectToAction("ViewAllMovies");
        }

        public IActionResult ViewAllMovies()
        {
            List<Movie> lst = _movieReposistory.GetAll();
            return View("ViewAllMovies", lst);
        }

        public IActionResult ViewAllCategories()
        {
            List<Category> lst = _categoryReposistory.GetAll();
            return View("ViewAllCategories", lst);
        }
    }
}
