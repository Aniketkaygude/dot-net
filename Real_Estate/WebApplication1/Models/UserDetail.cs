using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserDetail
    {

        [Key]
        public int UserDetailId { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "FirstName should be less than 35 char")]
        [MinLength(2, ErrorMessage = "FirstName should be more than 1 char")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "LastName should be less than 35 char")]
        [MinLength(2, ErrorMessage = "LastName should be more than 1 char")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max_Budget should be less than 15 char")]
        [Display(Name = "Max Budget")]
        public string Max_Budget { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "number should be of 10 digits")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Location should less than equal to 35 chars")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Property type should less than equal to 35 chars")]
        [Display(Name = "Property_Type")]
        public string Property_Type { get; set; }
    }
}
