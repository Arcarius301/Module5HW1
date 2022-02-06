using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfigureService _configureService;
        private readonly string _url;
        public ResourceService(IHttpClientService httpClientService, IConfigureService configureService)
        {
            _httpClientService = httpClientService;
            _configureService = configureService;
            _url = _configureService.AppSetting["url"];
        }

        public async Task<string?> GetResources()
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/unknown", HttpMethod.Get);
        }

        public async Task<string?> GetResource(int id)
        {
            return await _httpClientService.SendAsync(@$"{_url}/api/unknown/{id}", HttpMethod.Get);
        }
    }
}
