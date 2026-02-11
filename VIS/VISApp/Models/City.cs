using System.ComponentModel.DataAnnotations;

namespace VISApp.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
