using Footballers.Common;
using Footballers.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamJsonDto
    {
        [JsonProperty(nameof(Name))]
        [Required]
        [MinLength(ValidConstants.TeamNameMinLength)]
        [MaxLength(ValidConstants.TeamNameMaxLength)]
        [RegularExpression(@"[A-Za-z\d\s.-]{3,}")]
        public string  Name { get; set; }

        [JsonProperty(nameof(Nationality))]
        [Required]
        [MinLength(ValidConstants.TeamNationalityMinLength)]
        [MaxLength(ValidConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; }

        [JsonProperty(nameof(Trophies))]
        public string Trophies { get; set; }

        [JsonProperty(nameof(Footballers))]
        [NotMapped]
        public int[] Footballers { get; set; }
    }
}
