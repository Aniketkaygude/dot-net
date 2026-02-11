

using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class Contract : IContract
    {

        private readonly CDBContext context;

        public Contract()
        {
            context = new CDBContext();
        }

        public string ValidateUser(string UserEmailId, string UserPassword)
        {

            try
            {

                User u = context.Users.FirstOrDefault(u => u.UserEmailId == UserEmailId && u.UserPassword == UserPassword);
                if (u == null)
                {
                    return "";
                }
                else
                {

                    return u.UserEmailId;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }


        public bool RegisterUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public User? GetUser(string UserEmailId)
        {

            try
            {
                User u = context.Users.FirstOrDefault(u => u.UserEmailId == UserEmailId);
                if (u != null)
                {
                    return u;
                }
                else
                {

                    return u;
                }
            }
            catch
            {
                return new User();
            }

        }

        public bool UpdateUser(User user)
        {

            try
            {

                User u = context.Users.FirstOrDefault(u => u.UserId == user.UserId);

                if (u != null)
                {
                    Console.WriteLine("enter to update");
                    u.UserFirstName = user.UserFirstName;
                    u.UserLastName = user.UserLastName;
                    u.UserPassword = user.UserPassword;
                    u.UserEmailId = user.UserEmailId;

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {

                return false;
            }

        }

        public bool AddEmployee(Employee employee)
        {

            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Employee> GetEmployeeDetails()
        {

            return context.Employees.ToList<Employee>();
        }

        public bool UpdateEmployee(Employee employee)
        {

            try
            {

                Employee e = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (e != null)
                {

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

                    context.SaveChanges();

                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }

        }

        public bool DeleteEmployee(int EmployeeId)
        {

            try
            {

                Employee e = context.Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
                if (e != null)
                {
                    context.Employees.Remove(e);
                    context.SaveChanges();
                    return true;
                }

                return false;



            }
            catch
            {
                return false;
            }

        }

        public Employee? GetEmployeeById(int EmployeeId)
        {

            try
            {

                Employee e = context.Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
                if (e != null)
                {

                    return e;
                }

                return e;



            }
            catch
            {
                return null;
            }

        }



        public List<Employee> SearchEmployeesByCompany(string company)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(company))
                    return new List<Employee>();

                company = company.Trim().ToLower();

                return context.Employees
                    .Where(e => e.EmployeeCompany.ToLower().Contains(company))
                    .ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }


        public List<Employee> SearchEmployeesByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return new List<Employee>();

                name = name.Trim().ToLower();

                return context.Employees
                    .Where(e => e.EmployeeFullName.ToLower().Contains(name))
                    .ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }




    }
}
