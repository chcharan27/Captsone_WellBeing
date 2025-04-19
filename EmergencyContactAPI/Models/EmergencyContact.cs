namespace EmergencyContactAPI.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Relationship { get; set; }
    }
}
