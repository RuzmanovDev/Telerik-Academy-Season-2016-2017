using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Processing
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set;}


        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

    }
}
