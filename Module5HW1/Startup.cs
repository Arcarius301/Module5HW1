using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Startup
    {
        public async Task Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpClientService, HttpClientService>()
                .AddSingleton<IConfigureService, ConfigureService>()
                .AddTransient<IAuthorizationService, AuthorizationService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<Application>()
                .BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();
            await app!.Run();
        }
    }
}
