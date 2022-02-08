using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services.Abstractions;
using Module5HW1.Models;

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

        public async Task<ListUsersResponse?> GetUsers(int page)
        {
            return await _httpClientService.SendAsync<ListUsersResponse>(@$"{_url}/api/users?=page{page}", HttpMethod.Get);
        }

        public async Task<ListUsersResponse?> GetUsers(int page, int delay)
        {
            return await _httpClientService.SendAsync<ListUsersResponse>(@$"{_url}/api/users?=delay{delay}", HttpMethod.Get);
        }

        public async Task<SingleResourceResponse?> GetUser(int id)
        {
            return await _httpClientService.SendAsync<SingleResourceResponse>(@$"{_url}/api/users/{id}", HttpMethod.Get);
        }

        public async Task<CreateUserResponse?> CreateUser(UserRequest payload)
        {
            return await _httpClientService.SendAsync<CreateUserResponse>(@$"{_url}/api/users", HttpMethod.Post, payload);
        }

        public async Task<UpdateUserResponse?> UpdateUser(int id, UserRequest payload)
        {
            return await _httpClientService.SendAsync<UpdateUserResponse>(@$"{_url}/api/users/{id}", HttpMethod.Put, payload);
        }

        public async Task<UpdateUserResponse?> PatchUser(int id, UserRequest payload)
        {
            return await _httpClientService.SendAsync<UpdateUserResponse>(@$"{_url}/api/users/{id}", HttpMethod.Patch, payload);
        }

        public async Task DeleteUser(int id)
        {
            await _httpClientService.SendAsync<VoidResult>(@$"{_url}/api/users/{id}", HttpMethod.Delete);
        }
    }
}
