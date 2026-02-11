using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class EmployeeContext:DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost; port=3306; database=WebApi; user=root; password=dbms;";
            var SeverVersion =ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, SeverVersion);
        }

    }
}