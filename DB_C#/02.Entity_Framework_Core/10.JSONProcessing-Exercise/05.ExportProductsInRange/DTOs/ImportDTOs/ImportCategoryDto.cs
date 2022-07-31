using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.ImportDTOs
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

    }
}
