using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class AuthorizationUnsuccessfulResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; } = null!;
    }
}
