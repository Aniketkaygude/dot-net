using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        
        public Role UserRole { get; set; }
    }
}
