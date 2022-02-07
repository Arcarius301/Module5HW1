using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class AuthorizationUnsuccessfulRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
    }
}
