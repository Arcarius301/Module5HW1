using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IAuthorizationService
    {
        public Task<AuthorizationSuccessfulResponse?> RegisterSuccessful(AuthorizationSuccessfulRequest payload);
        public Task<AuthorizationUnsuccessfulResponse?> RegisterUnsuccessful(AuthorizationUnsuccessfulRequest payload);
        public Task<AuthorizationSuccessfulResponse?> LoginSuccessful(AuthorizationSuccessfulRequest payload);
        public Task<AuthorizationUnsuccessfulResponse?> LoginUnsuccessful(AuthorizationUnsuccessfulRequest payload);
    }
}
