using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IRepository
    {
        public bool AddUserDetail(UserDetail userDetail);
        public bool EditUserDetail(UserDetail userDetail);
        public List<UserDetail> GetUsersList();
        public AdminUser ValidateAdminUser(string email,string password);
        public UserDetail GetUserById(int id);
        public bool Delete(int id);
    }
}
