using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServices.Models
{
    public class Product_Details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryDetailsID { get; set; }
    }
}
