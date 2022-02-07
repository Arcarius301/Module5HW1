using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        public Task<string> GetUsers(int page);

        public Task<string> GetUsers(int page, int delay);

        public Task<string> GetUser(int id);

        public Task<string> AddUser(string payload);

        public Task<string> UpdateUser(int id, string payload);

        public Task<string> PatchUser(int id, string payload);

        public Task<string> DeleteUser(int id);
    }
}
