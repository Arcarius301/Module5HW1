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
        public Task<T?> SendAsync<T>(string url, HttpMethod httpMethod, object? payload = null)
            where T : class;
    }
}
