using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportCategoryByProductDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int Count { get; set; }

        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
