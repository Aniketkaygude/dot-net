using Microsoft.EntityFrameworkCore;
using ShoppingDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Repository
{
    public class ShoppingRepository : IShoppingRepository
    {

        private ShoppingContext context;
        public ShoppingRepository()
        {
            context = new ShoppingContext();
        }

        #region User 
        public bool Register(User entUser)
        {
            bool result = false;
            try
            {
                context.Users.Add(entUser);
                context.SaveChanges();
                result = true;

            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public User Login(string username, string password)
        {

            User user = null;

            try
            {
                user = context.Users.FirstOrDefault(u => u.UserId == username && u.Password == password);
            }
            catch (Exception e)
            {

                throw e;
            }
            return user;
        }

        public User GetUserByID(string userId)
        {
            User user = null;
            try
            {
                user = context.Users.Find(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        public bool UpdateProfile(User entUser)
        {
            bool result = false;
            User user = context.Users.Find(entUser.UserId);
            user.Address = entUser.Address;
            user.Email = entUser.Email;
            user.Name = entUser.Name;
            user.Password = entUser.Password;
            context.SaveChanges();
            result = true;

            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public int ResetPassword(string userid, string oldPass, string newPass)
        {

            bool result = false;

            try
            {
                User user = context.Users.Find(userid);
                if (user.Password == oldPass)
                {
                    user.Password = newPass;
                    context.SaveChanges();
                    return 1;

                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return -1;
        }
        #endregion



        #region Product
        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> products = null;

            try
            {
                products = context.Products.Where(p => p.ProductName.Contains(searchTerm)).Include(c => c.Category).ToList());
            }
            catch (Exception e) { throw e; }
            return products;
        }

        partial List<Product> GetProducts()
        {

            List<Product> products = null;
            try
            {
                products = context.Products.Include(c => c.Category).ToList();
            }
            catch (Exception e) { throw e; }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                product = context.Products.Where(p => p.ProductId == id).Include(c => c.Category).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return product;
        }

        public List<Product> GetProductByCategory(string category) {


            List<Product> products = null;
            try {

                products = context.Products.Where(p => p.Category.CategoryName == category).Include(c => c.Category).ToList();

            }
            catch (Exception e) {
                throw e;
            }
            return products;

        }


        public bool AddProduct(Product product)
        {

            bool flag = false;
            try {

                context.Products.Add(product);
                context.SaveChanges();
                flag = true;
            }
            catch (Exception e) {
                throw e;
            }
            return flag;
        }

        public bool RemoveProduct(int id)
        {
            bool flag = false;
            try {
                Product product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
                flag = true;

            }
            catch (Exception e) {
                throw e;
            }
            return flag;

        }

        public bool UpdateProductDetails(Product entProd)
        {
            bool flag = false;
            try {
                Product product = context.Products.Where(p => p.ProductId == entProd.ProductId).FirstOrDefault();

                product.ProductDescription = entProd.ProductDescription;
                product.ProductName = entProd.ProductName;
                product.UnitPrice = entProd.UnitPrice;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception e) {
                throw e;
            }

            return flag;
        }
        #endregion

        #region Category 

        public List<Category> GetCategories()
        {
            List<Category> categories = null;
            try {
                categories = context.Categories.ToList();
            }
            catch (Exception e) {
                throw e;
            }
            return categories;

        }

        public Category GetCategory(int id)
        {
            Category category = null;

            try {
                category = context.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
            }
            catch (Exception ex) {
                throw ex;
            }
            return category;
        }

        public bool AddCategory(Category category)
        {
            bool flag = false;

            try {
                context.Categories.Add(category);
                context.SaveChanges();
                flag = true;
            }
            catch (Exception ex) {
                throw ex;
            }
            return flag;
        }
        public bool RemoveCategory(int id)
        {
            bool flag = false;
            try {
                Category category = context.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
                context.Categories.Remove(category);
                context.SaveChanges();
                flag = true;
            }
            catch (Exception ex) {
                throw ex;
            }
            return flag;
        }

        public bool UpdateCategoryName(int id, string newName) { 
        
            bool flag = false;

            try { 
            Category cat = context.Categories.Where(p=>p.CategoryId == id).FirstOrDefault();
                cat.CategoryName = newName;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception ex) {
                throw ex;
            }
            return flag;

        }

        #endregion

        #region Order 
        public int PlaceOrder(Order order)
        {
            try { 
            context.Orders.Add(order);

                for (int i = 0; i < order.Items.Count; i++) {
                    order.Items[i].OrdetId = order.OrderId;
                    context.OrderItem.Add(order.Items[i]);
                }
                context.SaveChanges();
            }
            catch (Exception ex) { 
                throw ex;
            }
            return order.OrderId;
        }
        #endregion

    }
}
