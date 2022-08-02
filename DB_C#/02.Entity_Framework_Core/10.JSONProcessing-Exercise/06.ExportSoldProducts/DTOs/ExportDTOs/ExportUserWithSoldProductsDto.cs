using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportUserWithSoldProductsDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportSoldProductDto[] SoldProducts { get; set; }
    }
}
