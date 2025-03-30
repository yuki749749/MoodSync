namespace MoodSync.Models
{
    public class MoodEntry
    {
        public int Id { get; set; } // Primary key
        public string Mood { get; set; } = string.Empty; // "1" to "7"
        public DateTime Timestamp { get; set; }
    }
}