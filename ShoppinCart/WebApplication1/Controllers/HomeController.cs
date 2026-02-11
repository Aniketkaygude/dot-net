using Microsoft.AspNetCore.Mvc;
using ShoppingDAL.Repository;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShoppingRepository repo; // Changed to _repo to follow convention

        public HomeController(ILogger<HomeController> logger, IShoppingRepository repo)
        {
            _logger = logger;
            this.repo = repo; // Make sure to use the private field
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("isLoggedIn") != null &&
               HttpContext.Session.GetString("isLoggedIn") == "True")
            {

                if (HttpContext.Session.GetString("userRole") == "1")
                {
                    ViewData["Layout"] = "AdminLayout";
                }
                else
                {
                    ViewData["Layout"] = "UserLayout";
                }
            }
            else
            {

                ViewData["Layout"] = "HomeLayout";
            }
            return View();
        }

        public IActionResult ContactUs()
        {
            if (HttpContext.Session.GetString("isLoggedIn") != null &&
               HttpContext.Session.GetString("isLoggedIn") == "True")
            {

                if (HttpContext.Session.GetString("userRole") == "1")
                {
                    ViewData["Layout"] = "AdminLayout";
                }
                else
                {
                    ViewData["Layout"] = "UserLayout";
                }
            }
            else
            {
                ViewData["Layout"] = "HomeLayout";
            }
            return View();
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(IFormCollection form)
        {
            try
            {
                string uid = form["UserId"].ToString();
                string pass = form["Password"].ToString();
                _logger.LogInformation("uid: " + uid + "  pass=" + pass);
                ShoppingDAL.Model.User entUser = repo.Login(uid, pass);
                _logger.LogInformation(entUser.Name + entUser.UserRole);

                if (entUser != null) {
                    HttpContext.Session.SetString("isLoggedIn", "True");
                    HttpContext.Session.SetString("userName", entUser.Name);
                    HttpContext.Session.SetString("userRole", entUser.UserRoleId.ToString());
                    HttpContext.Session.SetString("userId", entUser.UserId);
                    return RedirectToAction("Index", "Product");
                }
;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Login Failed. Please try again.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout() {

            HttpContext.Session.Remove("isLoggedIn");
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("userRole");
            HttpContext.Session.Remove("userId");
            OrderController.Cart.Clear();

            return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Models.User mvcObj) {

            try {
             ShoppingDAL.Model.User entObj = new ShoppingDAL.Model.User();
             entObj.UserId = mvcObj.UserId;
             entObj.Email = mvcObj.Email;
             entObj.Name = mvcObj.Name;
             entObj.Password = mvcObj.Password;
             entObj.Address = mvcObj.Address;
             entObj.UserRoleId = 2;
              
             bool user =  repo.Register(entObj);
                if (user) {
                    TempData["Msg"] = "User Registered successfully. Please Login to proceed";
                    return RedirectToAction("Login");
                }
            }
            catch {
                ViewBag.Error = "Registration Failed";
            }
            return View();
        
        }


        [HttpGet]
        public IActionResult UpdateProfile()
        {
            try { 
             Models.User mvcObj  = new Models.User();

                if (HttpContext.Session.GetString("isLoggedIn") != null
                    && HttpContext.Session.GetString("isLoggedIn") == "True")
                {

                    var entUser = repo.GetUserByID(HttpContext.Session.GetString("userId"));
                    mvcObj.UserId = entUser.UserId;
                    mvcObj.Email = entUser.Email;
                    mvcObj.Name = entUser.Name;
                    mvcObj.Password = entUser.Password;
                    mvcObj.Address = entUser.Address;
                    return View(mvcObj);
                }
                else {

                    return RedirectToAction("Login", "Home");
                }
             
            
            }
            catch {


                return RedirectToAction("Error");
            }

        }

        [HttpPost]
        public IActionResult UpdateProfile()
        { 


        }

    }
}
