namespace AuthApi.Models
{
    public class User
    {
        public int Id { get; set; }                // Primary key
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? Phone { get; set; }
    }
}
