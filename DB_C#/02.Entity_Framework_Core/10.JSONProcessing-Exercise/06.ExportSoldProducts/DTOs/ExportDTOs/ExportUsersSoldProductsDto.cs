using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportUsersSoldProductsDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ExportUserSoldProductDto[] Products { get; set; }
    }
}
