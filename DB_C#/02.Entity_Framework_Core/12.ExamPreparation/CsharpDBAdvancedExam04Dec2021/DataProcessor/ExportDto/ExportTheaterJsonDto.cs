using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTheaterJsonDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty("Halls")]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty(nameof(TotalIncome))]
        public decimal TotalIncome { get; set; }

        [JsonProperty(nameof(Tickets))]
        public ExportTicketJsonDto[] Tickets { get; set; }
    }
}
