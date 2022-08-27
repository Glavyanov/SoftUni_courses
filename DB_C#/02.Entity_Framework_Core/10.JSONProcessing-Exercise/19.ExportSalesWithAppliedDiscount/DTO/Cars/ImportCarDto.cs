using Newtonsoft.Json;

namespace CarDealer.DTO.Cars
{
    [JsonObject]
    public class ImportCarDto
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        //[MinLength(1)] work and for arrays !!!!!
        public int[] PartsId { get; set; }
    }
}
