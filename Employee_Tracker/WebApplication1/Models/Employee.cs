using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {


        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be longer than 2 characters")]
        [MaxLength(50, ErrorMessage = "Name should be shorter than 51  characters")]
        public string EmployeeFullName { get; set; }



        [Required]
        [MaxLength(200, ErrorMessage = "should be less than 200 characters")]
        public string EmployeeAddress { get; set; }


        [Required]
        [MaxLength(13)]
        public string EmployeePhone { get; set; }


        [MaxLength(50)]
        [Required]
        public string EmployeeCompany { get; set; }

        [Required]
        public DateTime EmployeeJoinDate { get; set; }



        [Required]
        [Range(2, 4)]
        public int EmployeeExperience { get; set; }


        [Required]
        [MaxLength(20)]
        public string EmployeeCareerLevel { get; set; }


        [Required]
        [MaxLength(200)]
        public string EmployeeSkill { get; set; }


        [Required]
        public DateTime EmployeeOffShoreStartDate { get; set; }

        [Required]
        public DateTime EmployeeOffShoreEndDate { get; set; }


    }
}
