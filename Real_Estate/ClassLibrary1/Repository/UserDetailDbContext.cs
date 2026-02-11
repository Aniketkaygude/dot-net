using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class UserDetailDbContext : DbContext
    { 
        public DbSet<UserDetail>UserDetails { get; set; }
        public DbSet<AdminUser> AdminUser{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(local);Database=honpre;Trusted_Connection=True";TrustServerCertificate=True;);
            var connectionString = "server=localhost; port=3306; database=Real_Estate_Db; user=root; password=dbms;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

    }
}
