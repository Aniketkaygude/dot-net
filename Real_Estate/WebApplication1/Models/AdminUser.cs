using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
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
