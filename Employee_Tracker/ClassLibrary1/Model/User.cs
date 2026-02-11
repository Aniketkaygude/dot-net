using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    [Index(nameof(UserEmailId), IsUnique = true)]
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Required]
     
        public string UserFirstName  { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Required]
        public string UserEmailId { get; set; }

        [Required]
        public string UserPassword { get; set; }


    }
}
