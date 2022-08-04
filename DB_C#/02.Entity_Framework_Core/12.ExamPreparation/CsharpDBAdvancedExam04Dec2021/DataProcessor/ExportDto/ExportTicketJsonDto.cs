using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTicketJsonDto
    {
        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty(nameof(RowNumber))]
        public sbyte RowNumber { get; set; }
    }
}
