using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServices.Models
{
    public class Category_Details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CategoryID { get; set; }

        public string CategoryTitle { get; set; }
    }
}
