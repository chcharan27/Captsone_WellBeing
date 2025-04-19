using GlobalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IApiProxyService _proxy;

        public AuthController(IApiProxyService proxy)
        {
            _proxy = proxy;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register() =>
            await Forward("Auth", "register");

        [HttpPost("login")]
        public async Task<IActionResult> Login() =>
            await Forward("Auth", "login");

        private async Task<IActionResult> Forward(string serviceKey, string endpoint)
        {
            var response = await _proxy.ForwardRequest(Request, serviceKey, endpoint);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }
    }
}
