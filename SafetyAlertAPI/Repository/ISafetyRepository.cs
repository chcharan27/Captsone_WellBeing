using SafetyAlertAPI.Models;

namespace SafetyAlertAPI.Repository
{
    public interface ISafetyRepository
    {
        Task AddAlertAsync(Alert alert);
        Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(int userId);
    }
}
