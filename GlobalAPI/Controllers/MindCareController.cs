using GlobalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAPI.Controllers
{
    [ApiController]
    [Route("mindcare")]
    public class MindCareController : ControllerBase
    {
        private readonly IApiProxyService _proxy;

        public MindCareController(IApiProxyService proxy)
        {
            _proxy = proxy;
        }

        [HttpGet("entries")]
        public async Task<IActionResult> GetEntries() =>
            await Forward("MindCare", "entries");

        [HttpPost("entries")]
        public async Task<IActionResult> AddEntry() =>
            await Forward("MindCare", "entries");

        private async Task<IActionResult> Forward(string serviceKey, string endpoint)
        {
            var response = await _proxy.ForwardRequest(Request, serviceKey, endpoint);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }
    }
}
