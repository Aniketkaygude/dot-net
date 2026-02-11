using ClassLibrary1.Model;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository repo;
        
        public AdminController(IRepository repo)
        {
            this.repo = repo;
        } 

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminUser adminUser)
        {
            try {

                if (ModelState.IsValid) {
                    AdminUser adminuser = repo.ValidateAdminUser(adminUser.EmailId, adminUser.Password);
                    if (adminuser != null)
                    {
                        HttpContext.Session.SetString("email", adminuser.EmailId);
                        HttpContext.Session.SetString("password", adminuser.Password);
                        return RedirectToAction("Index", "UserDetail");

                    }
                    
                }

                return View("index");

            }
            catch { return View(); }

           
        }
    }
}
