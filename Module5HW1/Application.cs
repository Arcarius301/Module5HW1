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

            var registrationRequest = new AuthorizationSuccessfulRequest
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };
            var registrationRequest2 = new AuthorizationUnsuccessfulRequest
            {
                Email = "sydney@fife"
            };
            var loginRequest = new AuthorizationSuccessfulRequest
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };
            var loginRequest2 = new AuthorizationUnsuccessfulRequest
            {
                Email = "peter@klaven"
            };
            var createUserRequest = new UserRequest
            {
                Name = "morpheus",
                Job = "leader"
            };
            var updateUserRequest = new UserRequest
            {
                Name = "morpheus",
                Job = "zion resident"
            };

            list.Add(Task.Run(async () => { await _userService.GetUsers(2); }));
            list.Add(Task.Run(async () => { await _userService.GetUser(2); }));
            list.Add(Task.Run(async () => { await _userService.GetUser(23); }));
            list.Add(Task.Run(async () => { await _resourceService.GetResources(); }));
            list.Add(Task.Run(async () => { await _resourceService.GetResource(2); }));
            list.Add(Task.Run(async () => { await _resourceService.GetResource(23); }));
            list.Add(Task.Run(async () => { await _userService.CreateUser(createUserRequest); }));
            list.Add(Task.Run(async () => { await _userService.UpdateUser(2, updateUserRequest); }));
            list.Add(Task.Run(async () => { await _userService.PatchUser(2, updateUserRequest); }));
            list.Add(Task.Run(async () => { await _userService.DeleteUser(2); }));
            list.Add(Task.Run(async () => { await _authorizationService.RegisterSuccessful(registrationRequest); }));
            list.Add(Task.Run(async () => { await _authorizationService.RegisterUnsuccessful(registrationRequest2); }));
            list.Add(Task.Run(async () => { await _authorizationService.LoginSuccessful(loginRequest); }));
            list.Add(Task.Run(async () => { await _authorizationService.LoginUnsuccessful(loginRequest2); }));
            list.Add(Task.Run(async () => { await _userService.GetUsers(2, 3); }));
            await Task.WhenAll(list);
        }
    }
}
