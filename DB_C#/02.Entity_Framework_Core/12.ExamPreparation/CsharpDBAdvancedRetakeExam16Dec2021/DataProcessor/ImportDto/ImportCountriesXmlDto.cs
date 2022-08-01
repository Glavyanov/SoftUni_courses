using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesXmlDto
    {
        [XmlElement(nameof(CountryName))]
        [Required]
        [MinLength(ValidationConstants.CountryNameMinLength)]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string CountryName { get; set; }

        [XmlElement(nameof(ArmySize))]
        [Range(ValidationConstants.CountryArmySizeMinLength, ValidationConstants.CountryArmySizeMaxLength)]
        public int ArmySize { get; set; }

    }
}
