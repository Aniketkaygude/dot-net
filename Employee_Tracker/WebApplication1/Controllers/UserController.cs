using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    
    public class UserController : Controller
    {

        private readonly IContract repo;
        
        public UserController(IContract repo)
        {
             this.repo = repo;
        }


        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(User u)
        {
            if (ModelState.IsValid)
            {


                string email = repo.ValidateUser(u.UserEmailId , u.UserPassword);

                if(email.Length>0)
                {
                   
                    ViewBag.msg = "User alreadt exists";
                    return View();
                }
               
                  

                ClassLibrary1.Model.User clsUser  = new ClassLibrary1.Model.User();
                 clsUser.UserFirstName = u.UserFirstName;
                clsUser.UserLastName = u.UserLastName;
                clsUser.UserPassword = u.UserPassword;
                clsUser.UserEmailId = u.UserEmailId;
               

              bool user=repo.RegisterUser(clsUser);

                if (user) {
                    return RedirectToAction("LoginUser", "User");
                }
              
                return View("Error");




            }
            else
            {
                return View("Error");
            } 

           
        }


        [HttpGet]
        public IActionResult LoginUser() { 
        
         return View();
        }

        [HttpPost]
        public IActionResult LoginUser(string UserEmailId, string UserPassword) {

            try
            {
                 string email = repo.ValidateUser(UserEmailId, UserPassword);
                if (email.Length ==0) {
                    ViewBag.LoginMsg = "User doesn't exists";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("UserEmailId", email);
                    //HttpContext.Session.GetString()
                    return RedirectToAction("AddEmployee", "Employee");
                }

            }
            catch {
             return View("Error");
            }
           

        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginUser", "User");
        }

        [HttpGet]
        public IActionResult UpdateProfile()
        {
            try { 
            string UserEmialId = HttpContext.Session.GetString("UserEmailId");

                ClassLibrary1.Model.User u = repo.GetUser(UserEmialId);
                if (u == null) {
                    return View();
                }
                WebApplication1.Models.User m = new WebApplication1.Models.User();
                m.UserId = u.UserId;
                m.UserFirstName = u.UserFirstName;
                m.UserLastName = u.UserLastName;
                m.UserPassword = u.UserPassword;
                return View(m);
                 

            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult UpdateProfile(User user)
        {

            try {

                if (ModelState.IsValid) { 

                var b = new ClassLibrary1.Model.User();
                    b.UserId = user.UserId;
                    b.UserFirstName = user.UserFirstName;
                b.UserLastName = user.UserLastName;
                b.UserPassword = user.UserPassword;
                b.UserEmailId = user.UserEmailId;

               bool ans = repo.UpdateUser(b);
                ViewBag.msg = "";
                if (ans)
                {
                    ViewBag.msg = "User Updated Successfully";

                }
                else
                {
                   
                    ViewBag.msg = "Failed to Update";

                }

                }
                return View();

            }
            catch
            {
                return View();
            }

        }





    }
}
