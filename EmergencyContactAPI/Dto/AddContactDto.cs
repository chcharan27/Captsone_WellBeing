namespace EmergencyContactAPI.Dto
{
    public class AddContactDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Relationship { get; set; }
    }
}
