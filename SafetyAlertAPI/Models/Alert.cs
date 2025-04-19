namespace SafetyAlertAPI.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
