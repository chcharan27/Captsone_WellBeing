namespace MindCareAPI.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? MoodType { get; set; } // e.g., Happy, Anxious, Sad
        public string? Note { get; set; } // Optional thoughts
        public DateTime Timestamp { get; set; }
    }
}
