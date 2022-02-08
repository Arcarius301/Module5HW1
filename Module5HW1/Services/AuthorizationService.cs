using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module5HW1.Services.Abstractions;
using Module5HW1.Models;

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

        public async Task<AuthorizationSuccessfulResponse?> RegisterSuccessful(AuthorizationSuccessfulRequest payload)
        {
            return await _httpClientService.SendAsync<AuthorizationSuccessfulResponse>(@$"{_url}/api/register", HttpMethod.Post, payload);
        }

        public async Task<AuthorizationUnsuccessfulResponse?> RegisterUnsuccessful(AuthorizationUnsuccessfulRequest payload)
        {
            return await _httpClientService.SendAsync<AuthorizationUnsuccessfulResponse>(@$"{_url}/api/register", HttpMethod.Post, payload);
        }

        public async Task<AuthorizationSuccessfulResponse?> LoginSuccessful(AuthorizationSuccessfulRequest payload)
        {
            return await _httpClientService.SendAsync<AuthorizationSuccessfulResponse>(@$"{_url}/api/login", HttpMethod.Post, payload);
        }

        public async Task<AuthorizationUnsuccessfulResponse?> LoginUnsuccessful(AuthorizationUnsuccessfulRequest payload)
        {
            return await _httpClientService.SendAsync<AuthorizationUnsuccessfulResponse>(@$"{_url}/api/login", HttpMethod.Post, payload);
        }
    }
}
