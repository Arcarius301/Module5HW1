using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        public Task<ListUsersResponse?> GetUsers(int page);

        public Task<ListUsersResponse?> GetUsers(int page, int delay);

        public Task<SingleResourceResponse?> GetUser(int id);

        public Task<CreateUserResponse?> CreateUser(UserRequest payload);

        public Task<UpdateUserResponse?> UpdateUser(int id, UserRequest payload);

        public Task<UpdateUserResponse?> PatchUser(int id, UserRequest payload);

        public Task DeleteUser(int id);
    }
}
