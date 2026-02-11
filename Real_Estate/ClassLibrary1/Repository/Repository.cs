using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class Repository:IRepository
    {
        private readonly  UserDetailDbContext context;
         public Repository()
        {
            this.context = new UserDetailDbContext();
        }

        public bool AddUserDetail(UserDetail userDetail)
        {
            try
            {  
                if(userDetail!=null) {
                context.UserDetails.Add(userDetail);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public UserDetail GetUserById (int id)
        {
            UserDetail temp = null;
            try {

                 temp = context.UserDetails.FirstOrDefault(u=>u.UserDetailId == id);
                if (temp != null) { 
                 return temp;

                }
                return temp;
             
            }
            catch {
                return temp;
            }
        }

        public bool EditUserDetail(UserDetail userDetail)
        {
            try {
            
              UserDetail temp = context.UserDetails.FirstOrDefault(u=>u.UserDetailId == userDetail.UserDetailId);
                if (temp != null) { 
                 temp.FirstName = userDetail.FirstName;
                 temp.LastName = userDetail.LastName;
                 temp.UserDetailId = userDetail.UserDetailId;
                 temp.Max_Budget = userDetail.Max_Budget;
                 temp.Phone = userDetail.Phone;
                 temp.Location = userDetail.Location;
                  temp.Property_Type = userDetail.Property_Type;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { 
            return  false;
            }
        }
        public List<UserDetail> GetUsersList()
        {
            return context.UserDetails.ToList();
        }

        public bool Delete(int id)
        {

            try
            {

              UserDetail u  = GetUserById(id);
                if (u != null) {
                
                  context.UserDetails.Remove(u);
                    context.SaveChanges();
                    return true;
                }
                return false;
               
            }
            catch
            {
                return false;
            }

        }
        public AdminUser ValidateAdminUser(string email, string password)
        {
            AdminUser temp = null;
            try
            {

                temp = context.AdminUser.FirstOrDefault(u => u.EmailId == email && u.Password == password);
                return temp;
            }
            catch
            {
                return temp;
            }

        }
    }
}
