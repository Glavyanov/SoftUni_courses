using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTheatreJsonDto
    {
        [JsonProperty(nameof(Name))]
        [Required]
        [MinLength(ValidationConstants.TheatreNameMinLength)]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [JsonProperty(nameof(NumberOfHalls))]
        [Range(typeof(sbyte), ValidationConstants.TheatreNumberOfHallsMinRange, ValidationConstants.TheatreNumberOfHallsMaxRange)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty(nameof(Director))]
        [Required]
        [MinLength(ValidationConstants.TheatreDirectorMinLength)]
        [MaxLength(ValidationConstants.TheatreDirectorMaxLength)]
        public string Director { get; set; }

        [JsonProperty(nameof(Tickets))]
        public ImportTicketJsonDto[] Tickets { get; set; }
    }
}
