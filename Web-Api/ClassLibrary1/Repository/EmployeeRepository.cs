using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeContext context;
      public  EmployeeRepository()
        {
            this.context = new EmployeeContext();
        }

        public List<Employee> GetAllEmployees() {
            return context.Employees.ToList();
        }

        public Employee GetById(int id) { 
         
            return context.Employees.FirstOrDefault(e=>e.EmployeId==id);
        }

        public Employee AddEmployee(Employee employee) { 
         context.Employees.Add(employee); 
         context.SaveChanges();
         return employee;
        }

        public Employee UpdateEmployee(Employee employee) {

            Employee e = context.Employees.FirstOrDefault(e=>e.EmployeId==employee.EmployeId);

            if (e != null) { 
              e.Name = employee.Name;
              e.salary = employee.salary;
                context.SaveChanges();
              return e;
            }
            return e;
        }

        public bool DeleteEmployee(int id)
        {

            var emp = context.Employees.FirstOrDefault(e => e.EmployeId == id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return true;
            }

            return false;

        }

        }
}
