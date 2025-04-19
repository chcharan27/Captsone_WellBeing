using MindCareAPI.Models;

namespace MindCareAPI.Repository
{
    public interface IMindCareRepository
    {
        Task AddMoodAsync(Mood mood);
        Task<IEnumerable<Mood>> GetMoodHistoryAsync(int userId);
        Task<List<string>> GetWellnessTipsAsync();
    }
}
