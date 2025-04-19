using EmergencyContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmergencyContactAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
    }
}
