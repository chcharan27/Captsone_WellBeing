using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafetyAlertAPI.Dto;
using SafetyAlertAPI.Models;
using SafetyAlertAPI.Repository;

namespace SafetyAlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly ISafetyRepository _repository;

        public AlertController(ISafetyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendAlert([FromBody] AlertDto alertDto)
        {
            var alert = new Alert
            {
                UserId = alertDto.UserId,
                Message = alertDto.Message,
                Latitude = alertDto.Latitude,
                Longitude = alertDto.Longitude,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddAlertAsync(alert);
            return Ok(new { message = "Alert sent successfully." });
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetAlertHistory(int userId)
        {
            var alerts = await _repository.GetAlertsByUserIdAsync(userId);
            return Ok(alerts);
        }
    }
}
