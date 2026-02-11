using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace VISApp.Controllers
{
    public class AdminController : Controller
    {


        private readonly IVISRepo _repo;
        
      

        public AdminController(IVISRepo repo) { 
         _repo = repo;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string emailid,string password) {
         
            DataAccess.Model.AdminUser admin = _repo.ValidateUser(emailid, password);

            if (admin!= null)
            {
                HttpContext.Session.SetString("emailid", emailid);
                HttpContext.Session.SetString("password", password);
                return RedirectToAction("Create", "Voters");
            }
            else {
                ViewBag.error = "Invalid user name or password";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout() {
         HttpContext.Session.Clear();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult AddNewCity() { 
           return View();
        }

        [HttpPost]
        public IActionResult AddNewCity(City city) { 
          
            DataAccess.Model.City temp = new DataAccess.Model.City();
            temp.Name = city.Name;

            bool result = _repo.AddCity(temp);

            if (!result) {
                View("Error");
            }
            else
            {
                ViewBag.Message = "City Added";
            }
            return View();
        }

    }
}
