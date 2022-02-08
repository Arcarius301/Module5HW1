using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T?> SendAsync<T>(string url, HttpMethod httpMethod, object? payload = null)
            where T : class
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = httpMethod;

            if (payload != null)
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                httpMessage.Content = httpContent;
            }

            var result = await _httpClient.SendAsync(httpMessage);
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content) !;
        }
    }
}
