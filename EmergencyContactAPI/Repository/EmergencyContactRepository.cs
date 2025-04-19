using EmergencyContactAPI.Data;
using EmergencyContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmergencyContactAPI.Repository
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly AppDbContext _context;

        public EmergencyContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmergencyContact>> GetContactsByUserIdAsync(int userId)
        {
            return await _context.EmergencyContacts
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task AddContactAsync(EmergencyContact contact)
        {
            await _context.EmergencyContacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await _context.EmergencyContacts.FindAsync(contactId);
            if (contact != null)
            {
                _context.EmergencyContacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
