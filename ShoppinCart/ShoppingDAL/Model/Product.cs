using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        public string ProductDescription { get; set; }

        public double UnitPrice { get; set; }

        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
