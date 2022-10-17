using System.Text.Json.Serialization;

namespace LosMellizosAPI.Models
{
    public class CustomerClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Threshold { get; set; }
        public int Discount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
