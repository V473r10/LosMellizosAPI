namespace LosMellizosAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }  
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool Active { get; set; }
    }

    public enum Role
    {
        Dev = 0,
        Admin = 1,
        User = 2
    }
}
