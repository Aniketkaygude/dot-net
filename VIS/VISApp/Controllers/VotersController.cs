using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VISApp.Models;
namespace VISApp.Controllers
{
    public class VotersController : Controller
    {

        private readonly IVISRepo _repo;
        public VotersController(IVISRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Create()
        {

            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }

            List<DataAccess.Model.City> cities = _repo.GetCityList();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in cities)
            {

                SelectListItem selectedItem = new SelectListItem();
                selectedItem.Text = item.Name;
                listItems.Add(selectedItem);
            }

            ViewBag.Cities = listItems;

            return View();
        }

        [HttpPost]
        public IActionResult Create(VISApp.Models.Voter voters)
        {

            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (ModelState.IsValid)
            {

                DataAccess.Model.Voter temp = new DataAccess.Model.Voter();
                temp.VoterId = voters.VoterId;
                temp.VoterName = voters.VoterName;
                temp.Gender = voters.Gender;
                temp.Age = voters.Age;
                temp.MobileNumber = voters.MobileNumber;
                temp.Dob = voters.Dob;
                temp.EmailId = voters.EmailId;
                temp.City = voters.City;
                bool result = _repo.AddVoter(temp);

                if (!result)
                {
                    View("Error");
                }

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }

            List<DataAccess.Model.Voter> entityvoters = _repo.GetVoterList();
            List<VISApp.Models.Voter> voters = new List<VISApp.Models.Voter>();

            foreach (var item in entityvoters)
            {
                voters.Add(new VISApp.Models.Voter()
                {
                    VoterId = item.VoterId,
                    VoterName = item.VoterName,
                    Age = item.Age,
                    Dob = item.Dob,
                    Gender = item.Gender,
                    City = item.City,
                    EmailId = item.EmailId,
                    MobileNumber = item.MobileNumber,

                });
            }
            return View(voters);
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            try
            {
                DataAccess.Model.Voter dv = _repo.FindByPK(id);

                if (dv == null)
                {
                    return View("Error");
                }
                else
                {
                    var wv = new VISApp.Models.Voter();
                    wv.VoterId = dv.VoterId;
                    wv.VoterName = dv.VoterName;
                    wv.Age = dv.Age;
                    wv.Dob = dv.Dob;
                    wv.Gender = dv.Gender;
                    wv.City = dv.City;
                    wv.EmailId = dv.EmailId;
                    wv.MobileNumber = dv.MobileNumber;
                    return View(wv);
                }
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpPost]

        public IActionResult Edit(VISApp.Models.Voter voters)
        {
           try {

                if (ModelState.IsValid) {

                    DataAccess.Model.Voter temp = new DataAccess.Model.Voter();
                    temp.VoterId = voters.VoterId;
                    temp.VoterName = voters.VoterName;
                    temp.Gender = voters.Gender;
                    temp.Age = voters.Age;
                    temp.MobileNumber = voters.MobileNumber;
                    temp.Dob = voters.Dob;
                    temp.EmailId = voters.EmailId;
                    temp.City = voters.City;
                    
                   bool ans =  _repo.UpdateVoter(temp);

                    if(ans)
                    {
                        return RedirectToAction("Index");

                    }

                }
                return View("Error");
             
            }
           catch {

                return View("Error");
            }

        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                DataAccess.Model.Voter dv = _repo.FindByPK(id);

                if (dv == null)
                {
                    return View("Error");
                }
                else
                {
                    var wv = new VISApp.Models.Voter();
                    wv.VoterId = dv.VoterId;
                    wv.VoterName = dv.VoterName;
                    wv.Age = dv.Age;
                    wv.Dob = dv.Dob;
                    wv.Gender = dv.Gender;
                    wv.City = dv.City;
                    wv.EmailId = dv.EmailId;
                    wv.MobileNumber = dv.MobileNumber;
                    return View(wv);
                }
            }
            catch
            {
                return View("Error");
            }
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                DataAccess.Model.Voter dv = _repo.FindByPK(id);

                if (dv == null)
                {
                    return View("Error");
                }
                else
                {
                    var wv = new VISApp.Models.Voter();
                    wv.VoterId = dv.VoterId;
                    wv.VoterName = dv.VoterName;
                    wv.Age = dv.Age;
                    wv.Dob = dv.Dob;
                    wv.Gender = dv.Gender;
                    wv.City = dv.City;
                    wv.EmailId = dv.EmailId;
                    wv.MobileNumber = dv.MobileNumber;
                    return View(wv);
                }
            }
            catch
            {
                return View("Error");
            }
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            try { 
            
             bool ans = _repo.DeleteVoter(id);

                if (ans)
                {
                    return RedirectToAction("Index");
                }
                return View("Index");
              
            }
            catch {
             
                return View("Error");
            }
           
        }

    }
}
