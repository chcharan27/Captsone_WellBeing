namespace SafetyAlertAPI.Dto
{
    public class AlertDto
    {
        public int UserId { get; set; }
        public string? Message { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
