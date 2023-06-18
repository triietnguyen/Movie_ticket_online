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
        private MoviesContext _ctx;
        public AccountController(IUserReposistory userReposistory, MoviesContext ctx)
        {
            _userReposistory = userReposistory;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = _ctx.Users.Where(x=>x.UserName.Equals(user.UserName)&& x.Password.Equals(user.Password)).ToList().FirstOrDefault();
                if (u!=null)
                {
                    if (user.GroupId == 2)
                    {
                        HttpContext.Session.SetString("UserName", u.UserName.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserName", u.UserName.ToString());
                        return RedirectToAction("Index", "Home","Admin");
                    }
                    
                }
            }
            return View();

        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Account");
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