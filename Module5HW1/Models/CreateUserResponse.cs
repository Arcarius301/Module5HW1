using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class CreateUserResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("job")]
        public string Job { get; set; } = null!;
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
