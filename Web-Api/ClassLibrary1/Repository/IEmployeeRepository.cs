using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IEmployeeRepository
    {
       public List<Employee> GetAllEmployees();
       public Employee GetById(int id);
       public Employee AddEmployee(Employee employee);
       public Employee UpdateEmployee(Employee employee);
     public   bool DeleteEmployee(int id);


    }
}
