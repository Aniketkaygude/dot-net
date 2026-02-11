using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Index(nameof(UserEmailId), IsUnique = true)]
    public class User
    {

        [Key]
        public int UserId { get; set; }


        [Required]

        public string UserFirstName { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Required]
        public string UserEmailId { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
