using ClassLibrary1.Model;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IContract repo;
        public EmployeeController(IContract repo)
        {
            this.repo = repo;
        }

        [HttpGet]


        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {

            try
            {
                bool ans = false;
                if (ModelState.IsValid)
                {

                    ClassLibrary1.Model.Employee e = new ClassLibrary1.Model.Employee();
                    e.EmployeeFullName = employee.EmployeeFullName;
                    e.EmployeeAddress = employee.EmployeeAddress;
                    e.EmployeePhone = employee.EmployeePhone;
                    e.EmployeeCompany = employee.EmployeeCompany;
                    e.EmployeeJoinDate = employee.EmployeeJoinDate;
                    e.EmployeeExperience = employee.EmployeeExperience;
                    e.EmployeeCareerLevel = employee.EmployeeCareerLevel;
                    e.EmployeeSkill = employee.EmployeeSkill;
                    e.EmployeeOffShoreStartDate = employee.EmployeeOffShoreStartDate;
                    e.EmployeeOffShoreEndDate = employee.EmployeeOffShoreEndDate;
                    ans = repo.AddEmployee(e);

                    if (ans)
                    {
                        return RedirectToAction("ListAllEmployees", "Employee");
                    }


                }
                return View();

            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }


        [HttpGet]
        public IActionResult ListAllEmployees(Employee employee)
        {

            try
            {

                List<ClassLibrary1.Model.Employee> ClassEmp = repo.GetEmployeeDetails();

                List<WebApplication1.Models.Employee> WebEmp = new List<WebApplication1.Models.Employee>(); ;

                foreach (var i in ClassEmp)
                {
                    WebEmp.Add(new WebApplication1.Models.Employee()
                    {
                        EmployeeId = i.EmployeeId,
                        EmployeeFullName = i.EmployeeFullName,
                        EmployeeAddress = i.EmployeeAddress,
                        EmployeePhone = i.EmployeePhone,
                        EmployeeCompany = i.EmployeeCompany,
                        EmployeeJoinDate = i.EmployeeJoinDate,
                        EmployeeExperience = i.EmployeeExperience,
                        EmployeeCareerLevel = i.EmployeeCareerLevel,
                        EmployeeSkill = i.EmployeeSkill,
                        EmployeeOffShoreStartDate = i.EmployeeOffShoreStartDate,
                        EmployeeOffShoreEndDate = i.EmployeeOffShoreEndDate,
                    });
                }
                return View(WebEmp);

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
                ClassLibrary1.Model.Employee ClsEmp = repo.GetEmployeeById(id);
                if (ClsEmp == null)
                {
                    return View();

                }
                else
                {
                    WebApplication1.Models.Employee WbEmp = new WebApplication1.Models.Employee();

                    WbEmp.EmployeeId = ClsEmp.EmployeeId;
                    WbEmp.EmployeeAddress = ClsEmp.EmployeeAddress;
                    WbEmp.EmployeeFullName = ClsEmp.EmployeeFullName;
                    WbEmp.EmployeePhone = ClsEmp.EmployeePhone;
                    WbEmp.EmployeeCompany = ClsEmp.EmployeeCompany;
                    WbEmp.EmployeeJoinDate = ClsEmp.EmployeeJoinDate;
                    WbEmp.EmployeeExperience = ClsEmp.EmployeeExperience;
                    WbEmp.EmployeeCareerLevel = ClsEmp.EmployeeCareerLevel;
                    WbEmp.EmployeeSkill = ClsEmp.EmployeeSkill;
                    WbEmp.EmployeeOffShoreStartDate = ClsEmp.EmployeeOffShoreStartDate;
                    WbEmp.EmployeeOffShoreEndDate = ClsEmp.EmployeeOffShoreEndDate;

                    return View(WbEmp);
                }

            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            try
            {
                ClassLibrary1.Model.Employee ClsEmp = repo.GetEmployeeById(id);
                if (ClsEmp == null)
                {
                    return View();

                }
                else
                {
                    WebApplication1.Models.Employee WbEmp = new WebApplication1.Models.Employee();

                    WbEmp.EmployeeId = ClsEmp.EmployeeId;
                    WbEmp.EmployeeAddress = ClsEmp.EmployeeAddress;
                    WbEmp.EmployeeFullName = ClsEmp.EmployeeFullName;
                    WbEmp.EmployeePhone = ClsEmp.EmployeePhone;
                    WbEmp.EmployeeCompany = ClsEmp.EmployeeCompany;
                    WbEmp.EmployeeJoinDate = ClsEmp.EmployeeJoinDate;
                    WbEmp.EmployeeExperience = ClsEmp.EmployeeExperience;
                    WbEmp.EmployeeCareerLevel = ClsEmp.EmployeeCareerLevel;
                    WbEmp.EmployeeSkill = ClsEmp.EmployeeSkill;
                    WbEmp.EmployeeOffShoreStartDate = ClsEmp.EmployeeOffShoreStartDate;
                    WbEmp.EmployeeOffShoreEndDate = ClsEmp.EmployeeOffShoreEndDate;

                    return View(WbEmp);
                }

            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Edit(Employee WbEmp)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    ClassLibrary1.Model.Employee ClsEmp = new ClassLibrary1.Model.Employee();

                    //WebApplication1.Models.Employee WbEmp = new WebApplication1.Models.Employee();

                    ClsEmp.EmployeeId = WbEmp.EmployeeId;
                    ClsEmp.EmployeeAddress = WbEmp.EmployeeAddress;
                    ClsEmp.EmployeeFullName = WbEmp.EmployeeFullName;
                    ClsEmp.EmployeePhone = WbEmp.EmployeePhone;
                    ClsEmp.EmployeeCompany = WbEmp.EmployeeCompany;
                    ClsEmp.EmployeeJoinDate = WbEmp.EmployeeJoinDate;
                    ClsEmp.EmployeeExperience = WbEmp.EmployeeExperience;
                    ClsEmp.EmployeeCareerLevel = WbEmp.EmployeeCareerLevel;
                    ClsEmp.EmployeeSkill = WbEmp.EmployeeSkill;
                    ClsEmp.EmployeeOffShoreStartDate = WbEmp.EmployeeOffShoreStartDate;
                    ClsEmp.EmployeeOffShoreEndDate = WbEmp.EmployeeOffShoreEndDate;
                    bool ans = repo.UpdateEmployee(ClsEmp);
                    ViewBag.msg = "";
                    if (ans)
                    {
                        ViewBag.msg = "Employee " + ClsEmp.EmployeeId + "  Updated Successfully";
                        return View();

                    }

                }
                ViewBag.msg = " Failed to Update";
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        [HttpGet]
        public IActionResult SearchByName()
        {
            // Get all employees from repository
            var employeesFromRepo = repo.GetEmployeeDetails();

            // Convert to your MVC model list
            List<WebApplication1.Models.Employee> employees = new List<WebApplication1.Models.Employee>();

            foreach (var emp in employeesFromRepo)
            {
                employees.Add(new WebApplication1.Models.Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeFullName = emp.EmployeeFullName,
                    EmployeeAddress = emp.EmployeeAddress,
                    EmployeePhone = emp.EmployeePhone,
                    EmployeeCompany = emp.EmployeeCompany,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeExperience = emp.EmployeeExperience,
                    EmployeeCareerLevel = emp.EmployeeCareerLevel,
                    EmployeeSkill = emp.EmployeeSkill,
                    EmployeeOffShoreStartDate = emp.EmployeeOffShoreStartDate,
                    EmployeeOffShoreEndDate = emp.EmployeeOffShoreEndDate
                });
            }

            // Pass the list to the view
            return View(employees);
        }


        [HttpPost]
        public IActionResult SearchByName(string name)
        {
            // Call your repository search method
            var employeesFromRepo = repo.SearchEmployeesByName(name);
            List<WebApplication1.Models.Employee> employees = new List<WebApplication1.Models.Employee>();

            foreach (var emp in employeesFromRepo)
            {
                employees.Add(new WebApplication1.Models.Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeFullName = emp.EmployeeFullName,
                    EmployeeAddress = emp.EmployeeAddress,
                    EmployeePhone = emp.EmployeePhone,
                    EmployeeCompany = emp.EmployeeCompany,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeExperience = emp.EmployeeExperience,
                    EmployeeCareerLevel = emp.EmployeeCareerLevel,
                    EmployeeSkill = emp.EmployeeSkill,
                    EmployeeOffShoreStartDate = emp.EmployeeOffShoreStartDate,
                    EmployeeOffShoreEndDate = emp.EmployeeOffShoreEndDate
                });
            }

            // Pass the list to the view
            return View(employees);
        }







        [HttpGet]
        public IActionResult SearchByCompanyName()
        {
            // Get all employees from repository
            var employeesFromRepo = repo.GetEmployeeDetails();

            // Convert to your MVC model list
            List<WebApplication1.Models.Employee> employees = new List<WebApplication1.Models.Employee>();

            foreach (var emp in employeesFromRepo)
            {
                employees.Add(new WebApplication1.Models.Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeFullName = emp.EmployeeFullName,
                    EmployeeAddress = emp.EmployeeAddress,
                    EmployeePhone = emp.EmployeePhone,
                    EmployeeCompany = emp.EmployeeCompany,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeExperience = emp.EmployeeExperience,
                    EmployeeCareerLevel = emp.EmployeeCareerLevel,
                    EmployeeSkill = emp.EmployeeSkill,
                    EmployeeOffShoreStartDate = emp.EmployeeOffShoreStartDate,
                    EmployeeOffShoreEndDate = emp.EmployeeOffShoreEndDate
                });
            }

            // Pass the list to the view
            return View(employees);
        }


        [HttpPost]
        public IActionResult SearchByCompanyName(string name)
        {
            // Call your repository search method
            var employeesFromRepo = repo.SearchEmployeesByCompany(name);
            List<WebApplication1.Models.Employee> employees = new List<WebApplication1.Models.Employee>();

            foreach (var emp in employeesFromRepo)
            {
                employees.Add(new WebApplication1.Models.Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeFullName = emp.EmployeeFullName,
                    EmployeeAddress = emp.EmployeeAddress,
                    EmployeePhone = emp.EmployeePhone,
                    EmployeeCompany = emp.EmployeeCompany,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeExperience = emp.EmployeeExperience,
                    EmployeeCareerLevel = emp.EmployeeCareerLevel,
                    EmployeeSkill = emp.EmployeeSkill,
                    EmployeeOffShoreStartDate = emp.EmployeeOffShoreStartDate,
                    EmployeeOffShoreEndDate = emp.EmployeeOffShoreEndDate
                });
            }

            // Pass the list to the view
            return View(employees);
        }





    }
}
