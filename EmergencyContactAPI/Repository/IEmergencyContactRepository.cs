using EmergencyContactAPI.Models;

namespace EmergencyContactAPI.Repository
{
    public interface IEmergencyContactRepository
    {
        Task<IEnumerable<EmergencyContact>> GetContactsByUserIdAsync(int userId);
        Task AddContactAsync(EmergencyContact contact);
        Task DeleteContactAsync(int contactId);
    }
}
