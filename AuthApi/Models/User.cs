namespace AuthApi.Models
{
    public class User
    {
        public int Id { get; set; }                // Primary key
        public string? Username { get; set; }       // User's unique username
        public string? Password{ get; set; }
    }
}
