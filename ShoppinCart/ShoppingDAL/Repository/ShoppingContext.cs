using Microsoft.EntityFrameworkCore;
using ShoppingDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Repository
{
    public class ShoppingContext:DbContext
    { 

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string ConnectionString = @"Server=(local);Database=shoppingDb;Trusted_Connection=True;TrustServerCertificate=True";
            //optionsBuilder.UseSqlServer();


            var connectionString = "server=localhost; port=3306; database=ShoppingDb; user=root; password=dbms;";
            var version  =ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, version); 

            
        }
        
    }
}
