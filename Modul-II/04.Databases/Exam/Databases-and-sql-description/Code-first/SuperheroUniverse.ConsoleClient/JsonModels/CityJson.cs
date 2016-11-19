using Newtonsoft.Json;

namespace SuperheroUniverse.ConsoleClient.JsonModels
{
    public class CityJson
    {
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("planet")]
        public string Planet { get; set; }
    }
}