using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerName { get; set; }

    }
}
