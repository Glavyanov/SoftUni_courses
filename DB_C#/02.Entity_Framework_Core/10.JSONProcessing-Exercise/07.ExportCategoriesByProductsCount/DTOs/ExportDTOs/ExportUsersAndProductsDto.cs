using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace ProductShop.DTOs.ExportDTOs
{
    [JsonObject]
    public class ExportUsersAndProductsDto
    {
        
        [JsonProperty("users")]
        public ExportUserDto[] Users { get; set; }
    }
}
