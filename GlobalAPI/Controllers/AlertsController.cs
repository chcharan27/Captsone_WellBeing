using GlobalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAPI.Controllers
{
    [ApiController]
    [Route("alerts")]
    public class AlertsController : ControllerBase
    {
        private readonly IApiProxyService _proxy;

        public AlertsController(IApiProxyService proxy)
        {
            _proxy = proxy;
        }

        [HttpPost]
        public async Task<IActionResult> TriggerAlert() =>
            await Forward("Alerts", "");

        private async Task<IActionResult> Forward(string serviceKey, string endpoint)
        {
            var response = await _proxy.ForwardRequest(Request, serviceKey, endpoint);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }
    }
}
