using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class SingleUserResponse
    {
        [JsonProperty("data")]
        public User User { get; set; } = null!;
        [JsonProperty("support")]
        public SupportInfo SupportInfo { get; set; } = null!;
    }
}
