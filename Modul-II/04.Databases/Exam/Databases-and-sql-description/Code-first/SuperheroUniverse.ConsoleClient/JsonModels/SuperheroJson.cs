using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroUniverse.ConsoleClient.JsonModels
{
    public class SuperheroJson
    {
        public string Name { get; set; }

        public string SecretIdentity { get; set; }

        [JsonProperty("city")]
        public CityJson City { get; set; }

        [JsonProperty("alignment")]
        public string Alingment { get; set; }

        public string Story { get; set; }

        public List<string> Powers { get; set; }

        public List<string> Fractions { get; set; }
    }
}
