using Online_Movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

using System.Diagnostics;
using Online_Movie.Repository;

namespace Online_Movie.Controllers
{
    public class AccountController : Controller
    {
        private IUserReposistory _userReposistory;

        public AccountController(IUserReposistory userReposistory)
        {
            _userReposistory = userReposistory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.GroupId= 2;
            if (ModelState.IsValid)
            {
                //check Username in db
                bool isUserNameExist = _userReposistory.checkUsername(user.UserName);
                bool isEmailExist = _userReposistory.checkEmail(user.Email);
                if ( isEmailExist)
                {
                    ModelState.AddModelError(string.Empty, "Email is Exist!!!");
                    return View("Register");
                }
                if (isUserNameExist)
                {
                    ModelState.AddModelError(string.Empty, "Username is Exist!!!");
                    return View("Register");
                }
                else
                {
                    _userReposistory.Create(user);
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View("Register");
            }
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}