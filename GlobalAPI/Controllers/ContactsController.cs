using GlobalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAPI.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IApiProxyService _proxy;

        public ContactsController(IApiProxyService proxy)
        {
            _proxy = proxy;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts() =>
            await Forward("Contacts", "");

        [HttpPost]
        public async Task<IActionResult> AddContact() =>
            await Forward("Contacts", "");

        private async Task<IActionResult> Forward(string serviceKey, string endpoint)
        {
            var response = await _proxy.ForwardRequest(Request, serviceKey, endpoint);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }
    }
}
