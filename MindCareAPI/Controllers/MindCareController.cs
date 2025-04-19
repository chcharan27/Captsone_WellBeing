using Microsoft.AspNetCore.Mvc;
using MindCareAPI.Dto;
using MindCareAPI.Models;
using MindCareAPI.Repository;


namespace WellBeingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MindCareController : ControllerBase
    {
        private readonly IMindCareRepository _repository;

        public MindCareController(IMindCareRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("log")]
        public async Task<IActionResult> LogMood([FromBody] MoodDto moodDto)
        {
            var mood = new Mood
            {
                UserId = moodDto.UserId,
                MoodType = moodDto.MoodType,
                Note = moodDto.Note,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddMoodAsync(mood);
            return Ok(new { message = "Mood logged successfully." });
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetMoodHistory(int userId)
        {
            var history = await _repository.GetMoodHistoryAsync(userId);
            return Ok(history);
        }

        [HttpGet("tips")]
        public async Task<IActionResult> GetTips()
        {
            var tips = await _repository.GetWellnessTipsAsync();
            return Ok(tips);
        }
    }
}
