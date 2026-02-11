namespace WebApplication1.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }

        public User User { get; set; }

        public List<OrderItem> Items { get; set; }

        public float OrderCost { get; set; }

    }
}
