using Newtonsoft.Json;

namespace CarDealer.DTO.Suppliers
{
    [JsonObject]
    public class ExportSupplierDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(PartsCount))]
        public int PartsCount { get; set; }
    }
}
