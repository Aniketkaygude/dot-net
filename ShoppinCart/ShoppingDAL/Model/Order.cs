using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Model
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]

        public string UserId { get; set; }

        public List<OrderItem> Items{get; set;}

        public double OrderCost { get; set; }
    }
}
