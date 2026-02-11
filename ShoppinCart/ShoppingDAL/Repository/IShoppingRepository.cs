using ShoppingDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Repository
{
    public interface IShoppingRepository
    {

        #region User

        public bool Register(User entUser);
        public User Login(string username, string password);

        public User GetUserByID(string userId);

        public bool UpdateProfile(User entUser);

        public int ResetPassword(string userid, string oldPass, string newPass);

        #endregion

        #region Product
        public List<Product> SearchProduct(string searchTerm);
        public List<Product> GetProducts();
        public Product GetProductById(int id);

        public List<Product>GetProductByCategory(string category);
        public bool AddProduct(Product product);
        public bool RemoveProduct(int id);
        public bool UpdateProductDetails(Product entProd);

        #endregion

        #region Category 
        public List<Category> GetCategories();
        public Category GetCategory(int id);
        public bool AddCategory(Category category);
        public bool RemoveCategory(int id);
        public bool UpdateCategoryName(int id, string newName);
        #endregion

        #region Order
        public int PlaceOrder(Order order);
        #endregion
    }
}
