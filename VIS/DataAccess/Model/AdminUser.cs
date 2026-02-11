using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class AdminUser
    {
        [Key]
        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
