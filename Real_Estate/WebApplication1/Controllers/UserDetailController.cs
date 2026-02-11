
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.Repository;

namespace WebApplication1.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IRepository repo;
        public UserDetailController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                List<ClassLibrary1.Model.UserDetail> Clist = repo.GetUsersList();

                List<WebApplication1.Models.UserDetail> Wlist = new List<WebApplication1.Models.UserDetail>();

                foreach (var c in Clist)
                {

                    Wlist.Add(new WebApplication1.Models.UserDetail
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        UserDetailId = c.UserDetailId,
                        Max_Budget = c.Max_Budget,
                        Phone = c.Phone,
                        Location = c.Location,
                        Property_Type = c.Property_Type,
                    });

                }

                return View(Wlist);


            }
            catch
            {

                return View();
            }

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(UserDetail userDetail)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    ClassLibrary1.Model.UserDetail user = new ClassLibrary1.Model.UserDetail();

                    user.FirstName = userDetail.FirstName;
                    user.LastName = userDetail.LastName;
                    user.Phone = userDetail.Phone;
                    user.Location = userDetail.Location;
                    user.Max_Budget = userDetail.Max_Budget;
                    user.Property_Type = userDetail.Property_Type;

                    bool ans = repo.AddUserDetail(user);

                    if (ans)
                    {
                        return RedirectToAction("index", "UserDetail");
                    }
                }
                return View();

            }
            catch
            {
                return View();
            }


        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            try
            {

                ClassLibrary1.Model.UserDetail u = repo.GetUserById(id);
                if (u != null)
                {

                    WebApplication1.Models.UserDetail m = new WebApplication1.Models.UserDetail();
                    m.FirstName = u.FirstName;
                    m.LastName = u.LastName;
                    m.Phone = u.Phone;
                    m.Location = u.Location;
                    m.Max_Budget = u.Max_Budget;
                    m.Property_Type = u.Property_Type;
                    m.UserDetailId = u.UserDetailId;

                    return View(m);
                }

                return View();

            }
            catch
            {
                return View();
            }

        }

        [HttpPost]

        public IActionResult Edit(UserDetail userDetail)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ClassLibrary1.Model.UserDetail user = new ClassLibrary1.Model.UserDetail();
                    user.UserDetailId = userDetail.UserDetailId;
                    user.FirstName = userDetail.FirstName;
                    user.LastName = userDetail.LastName;
                    user.Phone = userDetail.Phone;
                    user.Location = userDetail.Location;
                    user.Max_Budget = userDetail.Max_Budget;
                    user.Property_Type = userDetail.Property_Type;

                    bool ans = repo.EditUserDetail(user);


                    if (ans)
                    {
                        return RedirectToAction("Index", "UserDetail");
                    }
                    return View();
                }
                return View();

            }
            catch
            {

                return View();
            }

        }



        [HttpGet]
        public IActionResult Details(int id)
        {

            try
            {

                ClassLibrary1.Model.UserDetail u = repo.GetUserById(id);
                if (u != null)
                {

                    WebApplication1.Models.UserDetail m = new WebApplication1.Models.UserDetail();
                    m.FirstName = u.FirstName;
                    m.LastName = u.LastName;
                    m.Phone = u.Phone;
                    m.Location = u.Location;
                    m.Max_Budget = u.Max_Budget;
                    m.Property_Type = u.Property_Type;
                    m.UserDetailId = u.UserDetailId;

                    return View(m);
                }

                return View();

            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {

            try
            {

                ClassLibrary1.Model.UserDetail u = repo.GetUserById(id);
                if (u != null)
                {

                    WebApplication1.Models.UserDetail m = new WebApplication1.Models.UserDetail();
                    m.FirstName = u.FirstName;
                    m.LastName = u.LastName;
                    m.Phone = u.Phone;
                    m.Location = u.Location;
                    m.Max_Budget = u.Max_Budget;
                    m.Property_Type = u.Property_Type;
                    m.UserDetailId = u.UserDetailId;

                    return View(m);
                }

                return View();

            }
            catch
            {
                return View();
            }

        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool ans = repo.Delete(id);
                if (ans)
                {
                    return RedirectToAction("Index", "UserDetail");
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
