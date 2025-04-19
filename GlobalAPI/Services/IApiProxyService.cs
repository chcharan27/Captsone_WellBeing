using Microsoft.AspNetCore.Http;

namespace GlobalAPI.Services
{
    public interface IApiProxyService
    {
        Task<HttpResponseMessage> ForwardRequest(HttpRequest request, string serviceKey, string endpoint);
    }
}
