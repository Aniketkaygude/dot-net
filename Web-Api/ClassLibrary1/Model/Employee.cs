using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Employee
    {
        [Key]
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }


    }
}
