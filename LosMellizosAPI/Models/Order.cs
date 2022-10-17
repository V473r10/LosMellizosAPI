namespace LosMellizosAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Address { get; set; }
        public List<Product>? Products { get; set; }
        public int ListPrice { get; set; }
        public int Discount { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Status { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
