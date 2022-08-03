using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTicketJsonDto
    {
        [JsonProperty(nameof(Price))]
        [Range(typeof(decimal), ValidationConstants.TicketPriceMinRange, ValidationConstants.TicketPriceMaxRange)]
        public decimal Price { get; set; }

        [JsonProperty(nameof(RowNumber))]
        [Range(typeof(sbyte), ValidationConstants.TicketRowNumberMinRange, ValidationConstants.TicketRowNumberMaxRange)]
        public sbyte RowNumber { get; set; }

        [JsonProperty(nameof(PlayId))]
        public int PlayId { get; set; }
    }
}
