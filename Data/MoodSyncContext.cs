using Microsoft.EntityFrameworkCore;
using MoodSync.Models;

namespace MoodSync.Data
{
    public class MoodSyncContext : DbContext
    {
        public DbSet<MoodEntry> MoodEntries { get; set; } = null!;

        public MoodSyncContext(DbContextOptions<MoodSyncContext> options)
            : base(options)
        {
        }
    }
}