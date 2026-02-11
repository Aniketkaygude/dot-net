using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IContract
    {

        public string ValidateUser(string UserEmailId, string UserPassword);
        public bool RegisterUser(User user);

        public User GetUser(string UserEmailId);

        public bool UpdateUser (User user);

        public bool AddEmployee(Employee employee);

        public List<Employee> GetEmployeeDetails();

        public  bool UpdateEmployee(Employee employee);

        public bool DeleteEmployee(int EmployeeId);

        public Employee GetEmployeeById(int EmployeeId);

        public List<Employee> SearchEmployeesByName(string Name);
        public List<Employee> SearchEmployeesByCompany(string Name);

    }
}
