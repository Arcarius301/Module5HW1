using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfigureService _configureService;
        private readonly string _url;

        public AuthorizationService(IHttpClientService httpClientService, IConfigureService configureService)
        {
            _httpClientService = httpClientService;
            _configureService = configureService;
            _url = _configureService.AppSetting["url"];
        }

        public async Task<string?> Register(string payload)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/register", HttpMethod.Post, payload);
        }

        public async Task<string?> Login(string payload)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/login", HttpMethod.Post, payload);
        }
    }
}
