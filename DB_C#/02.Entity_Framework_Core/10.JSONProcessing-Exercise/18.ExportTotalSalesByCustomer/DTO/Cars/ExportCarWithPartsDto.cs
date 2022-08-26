using CarDealer.DTO.Parts;
using Newtonsoft.Json;

namespace CarDealer.DTO.Cars
{
    [JsonObject]
    public class ExportCarWithPartsDto
    {
        [JsonProperty("car")]
        public ExportCarInfoDto Car { get; set; }

        [JsonProperty("parts")]
        public ExportPartInfoDto[] Parts { get; set; }
    }
}
