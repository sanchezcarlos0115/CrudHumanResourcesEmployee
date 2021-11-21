using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Model
{
    public class PersonaType
    {

        [JsonPropertyName("businessentity_id")]
        public int BusinessEntityId { get; set; }

        [JsonPropertyName("namedescription")]
        public string NameDescription { get; set; }
    }
}
