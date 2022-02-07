using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = null!;
        [JsonProperty("avatar")]
        public string Avatar { get; set; } = null!;
    }
}
