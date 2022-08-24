using Newtonsoft.Json;

namespace CarDealer.DTO.Parts
{
    [JsonObject]
    public class ExportPartInfoDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Price))]
        public string Price { get; set; }
    }
}
