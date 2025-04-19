using EmergencyContactAPI.Dto;
using EmergencyContactAPI.Models;
using EmergencyContactAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactsController : ControllerBase
    {
        private readonly IEmergencyContactRepository _repo;

        public EmergencyContactsController(IEmergencyContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetContacts(int userId)
        {
            var contacts = await _repo.GetContactsByUserIdAsync(userId);
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] AddContactDto dto)
        {
            var contact = new EmergencyContact
            {
                UserId = dto.UserId,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Relationship = dto.Relationship
            };

            await _repo.AddContactAsync(contact);
            return Ok(new { message = "Contact added successfully" });
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteContact(int UserId)
        {
            await _repo.DeleteContactAsync(UserId);
            return Ok(new { message = "Contact deleted successfully" });
        }
    }
}
