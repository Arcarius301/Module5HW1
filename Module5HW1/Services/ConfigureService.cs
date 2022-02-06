using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class ConfigureService : IConfigureService
    {
        public ConfigureService()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IConfiguration AppSetting { get; } = null!;
    }
}
