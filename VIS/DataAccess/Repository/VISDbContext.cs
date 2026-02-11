using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class VISDbContext:DbContext
    {
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<City>Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost; port=3306; database=VoterDb; user=root; password=dbms;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
         
     }
}
