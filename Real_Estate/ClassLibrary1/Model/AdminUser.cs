using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class AdminUser
    {
        [Key]
        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
