using Microsoft.EntityFrameworkCore;
using MindCareAPI.Models;

namespace WellBeingApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Mood> Moods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
