using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerXmlDto
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(ValidConstants.FootballerNameMinLength)]
        [MaxLength(ValidConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(ContractStartDate))]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement(nameof(ContractEndDate))]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement(nameof(BestSkillType))]
        [Required]
        public string BestSkillType { get; set; }

        [XmlElement(nameof(PositionType))]
        [Required]
        public string PositionType { get; set; }
    }
}
