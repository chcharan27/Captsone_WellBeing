using GlobalAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace GlobalAPI.Services
{
    public class ApiProxyService : IApiProxyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public ApiProxyService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<HttpResponseMessage> ForwardRequest(HttpRequest request, string serviceKey, string endpoint)
        {
            var client = _clientFactory.CreateClient();
            var baseUrl = _config[$"ServiceUrls:{UrlMappings.BaseUrls[serviceKey]}"];
            var fullUrl = $"{baseUrl}/{endpoint}";

            var proxyRequest = new HttpRequestMessage(new HttpMethod(request.Method), fullUrl);

            if (request.ContentLength > 0)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body);
                var body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                proxyRequest.Content = new StringContent(body, System.Text.Encoding.UTF8, request.ContentType);
            }

            if (request.Headers.ContainsKey("Authorization"))
            {
                proxyRequest.Headers.Authorization = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]);
            }

            return await client.SendAsync(proxyRequest);
        }
    }
}
