using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class SupportInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; } = null!;
        [JsonProperty("text")]
        public string Text { get; set; } = null!;
    }
}
