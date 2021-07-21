namespace Promotion.GRPC.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public string ProductImage { get; set; }
    }
}
