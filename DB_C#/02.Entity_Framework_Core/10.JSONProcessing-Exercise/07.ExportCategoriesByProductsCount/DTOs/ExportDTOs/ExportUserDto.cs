using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportUserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public ExportUsersSoldProductsDto SoldProducts { get; set; }
    }
}
