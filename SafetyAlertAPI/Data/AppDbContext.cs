using Microsoft.EntityFrameworkCore;
using SafetyAlertAPI.Models;
using System.Collections.Generic;

namespace SafetyAlertAPI.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Alert> Alerts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
