using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportFootballerDto
    {
        [JsonProperty(nameof(FootballerName))]
        public string FootballerName { get; set; }

        [JsonProperty(nameof(ContractStartDate))]
        public string ContractStartDate { get; set; }

        [JsonProperty(nameof(ContractEndDate))]
        public string ContractEndDate { get; set; }

        [JsonProperty(nameof(BestSkillType))]
        public string BestSkillType { get; set; }


        [JsonProperty(nameof(PositionType))]
        public string PositionType { get; set; }
    }
}
