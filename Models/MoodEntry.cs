namespace MoodSync.Models
{
    public class MoodEntry
    {
        public int Id { get; set; } // Primary key
        public string Mood { get; set; } = string.Empty; // "Happy", "Neutral", "Sad"
        public DateTime Timestamp { get; set; }
    }
}