using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfigureService _configureService;
        private readonly string _url;
        public UserService(IHttpClientService httpClientService, IConfigureService configureService)
        {
            _httpClientService = httpClientService;
            _configureService = configureService;
            _url = _configureService.AppSetting["url"];
        }

        public async Task<string> GetUsers(int page)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users?=page{page}", HttpMethod.Get);
        }

        public async Task<string> GetUsers(int page, int delay)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users?=delay{delay}", HttpMethod.Get);
        }

        public async Task<string> GetUser(int id)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users/{id}", HttpMethod.Get);
        }

        public async Task<string> AddUser(string payload)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users", HttpMethod.Post, payload);
        }

        public async Task<string> UpdateUser(int id, string payload)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users/{id}", HttpMethod.Put, payload);
        }

        public async Task<string> PatchUser(int id, string payload)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users/{id}", HttpMethod.Patch, payload);
        }

        public async Task<string> DeleteUser(int id)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/users/{id}", HttpMethod.Delete);
        }
    }
}
