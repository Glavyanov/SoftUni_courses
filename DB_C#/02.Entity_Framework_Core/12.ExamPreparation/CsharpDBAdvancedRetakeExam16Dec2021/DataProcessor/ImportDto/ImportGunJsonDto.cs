using Artillery.Common;
using Artillery.Data.Models.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportGunJsonDto
    {
        [JsonProperty(nameof(ManufacturerId))]
        public int ManufacturerId { get; set; }

        [JsonProperty(nameof(GunWeight))]
        [Range(ValidationConstants.GunWeightMinValue, ValidationConstants.GunWeightMaxValue)]
        public int GunWeight { get; set; }

        [JsonProperty(nameof(BarrelLength))]
        [Range(ValidationConstants.GunBarrelLengthMinValue, ValidationConstants.GunBarrelLengthMaxValue)]
        public double BarrelLength { get; set; }

        [JsonProperty(nameof(NumberBuild))]
        public int? NumberBuild { get; set; }

        [JsonProperty(nameof(Range))]
        [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
        public int Range { get; set; }

        [JsonProperty(nameof(GunType))]
        [Required]
        [NotMapped]
        public string GunType { get; set; }

        public int ShellId { get; set; }

        [JsonProperty(nameof(Countries))]
        public ImportCountryJsonDto[]  Countries { get; set; }
    }
}
