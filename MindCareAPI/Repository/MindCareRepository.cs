using Microsoft.EntityFrameworkCore;
using MindCareAPI.Models;
using WellBeingApi.Data;

namespace MindCareAPI.Repository
{
    public class MindCareRepository : IMindCareRepository
    {
        private readonly AppDbContext _context;

        public MindCareRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMoodAsync(Mood mood)
        {
            await _context.Moods.AddAsync(mood);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mood>> GetMoodHistoryAsync(int userId)
        {
            return await _context.Moods
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task<List<string>> GetWellnessTipsAsync()
        {
            // In real apps: get from DB. Here: hardcoded tips.
            return await Task.FromResult(new List<string>
            {
                "Take a 5-minute break and breathe deeply.",
                "Stay hydrated. Drink a glass of water.",
                "Write down one thing you're grateful for today.",
                "Stretch for 2 minutes — your body will thank you.",
                "Step outside for a quick walk or fresh air."
            });
        }
    }
}
