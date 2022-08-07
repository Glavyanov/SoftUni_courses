using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachXmlDto
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(ValidConstants.CoachNameMinLength)]
        [MaxLength(ValidConstants.CoachNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(Nationality))]
        [Required]
        public string Nationality { get; set; }

        [XmlArray(nameof(Footballers))]
        public ImportFootballerXmlDto[] Footballers { get; set; }
    }
}
