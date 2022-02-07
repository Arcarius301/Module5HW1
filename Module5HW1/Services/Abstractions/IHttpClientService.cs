using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Module5HW1.Services.Abstractions
{
    public interface IHttpClientService
    {
        public Task<string> SendAsync(string url, HttpMethod httpMethod, string payload);
        public Task<string> SendAsync(string url, HttpMethod httpMethod);
    }
}
