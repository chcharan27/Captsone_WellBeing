using Microsoft.EntityFrameworkCore;
using SafetyAlertAPI.Data;
using SafetyAlertAPI.Models;
using System;

namespace SafetyAlertAPI.Repository
{
    public class SafetyRepository: ISafetyRepository
    {
        private readonly AppDbContext _context;

        public SafetyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAlertAsync(Alert alert)
        {
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(int userId)
        {
            return await _context.Alerts
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Timestamp).ToListAsync();
        }
    }
}
