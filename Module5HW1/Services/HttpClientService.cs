using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _httpClient;
        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string?> SendAsync(string url, HttpMethod httpMethod, string payload)
        {
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = httpMethod;
            httpMessage.Content = httpContent;

            var result = await _httpClient.SendAsync(httpMessage);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<string?> SendAsync(string url, HttpMethod httpMethod)
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = httpMethod;

            var result = await _httpClient.SendAsync(httpMessage);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var responce = await result.Content.ReadAsStringAsync();
                return responce;
            }
            else
            {
                return null;
            }
        }
    }
}
