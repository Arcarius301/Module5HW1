using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Services.Abstractions
{
    public interface IAuthorizationService
    {
        public Task<string> Register(string payload);
        public Task<string> Login(string payload);
    }
}
