using System.Text.Json.Serialization;

namespace LosMellizosAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; }
        public int Class { get; set; }
        
        [JsonIgnore]
        public virtual CustomerClass? CustomerClass { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }

    public enum Class
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3
    }
}
