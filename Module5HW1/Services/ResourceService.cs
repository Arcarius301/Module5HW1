using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services.Abstractions;
using Module5HW1.Models;

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

        public async Task<ListResourcesResponse?> GetResources()
        {
            return await _httpClientService.SendAsync<ListResourcesResponse>(@$"{_url}/api/unknown", HttpMethod.Get);
        }

        public async Task<SingleResourceResponse?> GetResource(int id)
        {
            return await _httpClientService.SendAsync<SingleResourceResponse>(@$"{_url}/api/unknown/{id}", HttpMethod.Get);
        }
    }
}
