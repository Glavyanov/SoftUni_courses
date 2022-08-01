using Artillery.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerXmlDto
    {
        [XmlElement(nameof(ManufacturerName))]
        [Required]
        [MinLength(ValidationConstants.ManufacturerNameMinLength)]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        public string ManufacturerName { get; set; }

        [XmlElement(nameof(Founded))]
        [Required]
        [MinLength(ValidationConstants.ManufacturerFoundedMinLength)]
        [MaxLength(ValidationConstants.ManufacturerFoundedMaxLength)]
        public string Founded { get; set; }

    }
}
