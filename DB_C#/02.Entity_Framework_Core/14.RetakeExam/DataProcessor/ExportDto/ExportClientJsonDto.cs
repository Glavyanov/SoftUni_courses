using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportClientJsonDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Trucks))]
        public ExportTruckJsonDto[] Trucks { get; set; }
    }
}
