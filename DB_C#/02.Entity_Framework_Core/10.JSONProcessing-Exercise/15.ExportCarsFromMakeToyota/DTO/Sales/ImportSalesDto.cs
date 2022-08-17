using Newtonsoft.Json;

namespace CarDealer.DTO.Sales
{
    [JsonObject]
    public class ImportSalesDto
    {
        [JsonProperty("carId")]
        public int CarId { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}
