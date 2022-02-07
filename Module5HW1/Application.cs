using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module5HW1.Services.Abstractions;
using Module5HW1.Services;
using Module5HW1.Models;

namespace Module5HW1
{
    public class Application
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IResourceService _resourceService;
        private readonly IUserService _userService;

        public Application(IAuthorizationService authorizationService, IResourceService resourceService, IUserService userService)
        {
            _authorizationService = authorizationService;
            _resourceService = resourceService;
            _userService = userService;
        }

        public async Task Run()
        {
            var list = new List<Task>();
            list.Add(Task.Run(async () => { await GetListUsers(); }));
            list.Add(Task.Run(async () => { await GetSingleUser(); }));
            list.Add(Task.Run(async () => { await GetSingleUserNotFound(); }));
            list.Add(Task.Run(async () => { await GetListResources(); }));
            list.Add(Task.Run(async () => { await GetSingleResource(); }));
            list.Add(Task.Run(async () => { await GetSingleResourceNotFound(); }));
            list.Add(Task.Run(async () => { await CreateUser(); }));
            list.Add(Task.Run(async () => { await UpdateUser(); }));
            list.Add(Task.Run(async () => { await PatchUser(); }));
            list.Add(Task.Run(async () => { await DeleteUser(); }));
            list.Add(Task.Run(async () => { await RegisterSuccessful(); }));
            list.Add(Task.Run(async () => { await RegisterUnsuccessful(); }));
            list.Add(Task.Run(async () => { await LoginSuccessful(); }));
            list.Add(Task.Run(async () => { await LoginUnsuccessful(); }));
            list.Add(Task.Run(async () => { await GetListUsersDelayed(); }));
            await Task.WhenAll(list);
        }

        private async Task<AuthorizationSuccessfulResponse> RegisterSuccessful()
        {
            var payload = new AuthorizationSuccessfulRequest
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };
            var result = await _authorizationService.Register(JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[POST REGISTER SUCCESSFUL]: {result}");
            return JsonConvert.DeserializeObject<AuthorizationSuccessfulResponse>(result) !;
        }

        private async Task<AuthorizationUnsuccessfulResponse> RegisterUnsuccessful()
        {
            var payload = new AuthorizationUnsuccessfulRequest
            {
                Email = "sydney@fife"
            };
            var result = await _authorizationService.Register(JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[POST REGISTER UNSUCCESSFUL]: {result}");
            return JsonConvert.DeserializeObject<AuthorizationUnsuccessfulResponse>(result) !;
        }

        private async Task<AuthorizationSuccessfulResponse> LoginSuccessful()
        {
            var payload = new AuthorizationSuccessfulRequest
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };
            var result = await _authorizationService.Login(JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[POST LOGIN SUCCESSFUL]: {result}");
            return JsonConvert.DeserializeObject<AuthorizationSuccessfulResponse>(result) !;
        }

        private async Task<AuthorizationUnsuccessfulResponse> LoginUnsuccessful()
        {
            var payload = new AuthorizationUnsuccessfulRequest
            {
                Email = "peter@klaven"
            };
            var result = await _authorizationService.Login(JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[POST LOGIN UNSUCCESSFUL]: {result}");
            return JsonConvert.DeserializeObject<AuthorizationUnsuccessfulResponse>(result) !;
        }

        private async Task<ListUsersResponse> GetListUsers()
        {
            var result = await _userService.GetUsers(2);
            Console.WriteLine($"[GET LIST USERS]: {result}");
            return JsonConvert.DeserializeObject<ListUsersResponse>(result) !;
        }

        private async Task<SingleUserResponse> GetSingleUser()
        {
            var result = await _userService.GetUser(2);
            Console.WriteLine($"[GET SINGLE USER]: {result}");
            return JsonConvert.DeserializeObject<SingleUserResponse>(result) !;
        }

        private async Task GetSingleUserNotFound()
        {
            var result = await _userService.GetUser(23);
            Console.WriteLine($"[GET SINGLE USER NOT FOUND]: {result}");
        }

        private async Task<ListResourcesResponse> GetListResources()
        {
            var result = await _resourceService.GetResources();
            Console.WriteLine($"[GET LIST RESOURCE]: {result}");
            return JsonConvert.DeserializeObject<ListResourcesResponse>(result) !;
        }

        private async Task<SingleResourceResponse> GetSingleResource()
        {
            var result = await _resourceService.GetResource(2);
            Console.WriteLine($"[GET SINGLE RESOURCE]: {result}");
            return JsonConvert.DeserializeObject<SingleResourceResponse>(result) !;
        }

        private async Task GetSingleResourceNotFound()
        {
            var result = await _resourceService.GetResource(23);
            Console.WriteLine($"[GET SINGLE RESOURCE NOT FOUND]: {result}");
        }

        private async Task<CreateUserResponse> CreateUser()
        {
            var payload = new UserRequest
            {
                Name = "morpheus",
                Job = "leader"
            };
            var result = await _userService.AddUser(JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[POST CREATE]: {result}");
            return JsonConvert.DeserializeObject<CreateUserResponse>(result) !;
        }

        private async Task<UpdateUserResponse> UpdateUser()
        {
            var payload = new UserRequest
            {
                Name = "morpheus",
                Job = "zion resident"
            };
            var result = await _userService.UpdateUser(2, JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[PUT UPDATE]: {result}");
            return JsonConvert.DeserializeObject<UpdateUserResponse>(result) !;
        }

        private async Task<UpdateUserResponse> PatchUser()
        {
            var payload = new UserRequest
            {
                Name = "morpheus",
                Job = "zion resident"
            };
            var result = await _userService.PatchUser(2, JsonConvert.SerializeObject(payload));
            Console.WriteLine($"[PATCH UPDATE]: {result}");
            return JsonConvert.DeserializeObject<UpdateUserResponse>(result) !;
        }

        private async Task DeleteUser()
        {
            await _userService.DeleteUser(2);
        }

        private async Task<ListUsersResponse> GetListUsersDelayed()
        {
            var result = await _userService.GetUsers(2, 3);
            Console.WriteLine($"[GET DELAYED RESPONSE]: {result}");
            return JsonConvert.DeserializeObject<ListUsersResponse>(result) !;
        }
    }
}
