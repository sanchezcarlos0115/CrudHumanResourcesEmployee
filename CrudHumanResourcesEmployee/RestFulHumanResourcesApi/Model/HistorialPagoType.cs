using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Model
{
    public class HistorialPagoType
    {
        [JsonPropertyName("businessentityId")]
        public int BusinessEntityId { get; set; }

        [JsonPropertyName("ratechangedate")]
        public DateTime RateChangeDate { get; set; }
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }
        [JsonPropertyName("payfrequency")]
        public short PayFrequency { get; set; }
    }
}
