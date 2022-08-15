using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTruckJsonDto
    {
        [JsonProperty(nameof(TruckRegistrationNumber))]
        public string TruckRegistrationNumber { get; set; }

        [JsonProperty(nameof(VinNumber))]
        public string VinNumber { get; set; }

        [JsonProperty(nameof(TankCapacity))]
        public int TankCapacity { get; set; }

        [JsonProperty(nameof(CargoCapacity))]
        public int CargoCapacity { get; set; }

        [JsonProperty(nameof(CategoryType))]
        public string CategoryType { get; set; }

        [JsonProperty(nameof(MakeType))]
        public string MakeType { get; set; }
    }
}
