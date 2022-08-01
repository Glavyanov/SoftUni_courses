using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellXmlDto
    {
        [XmlElement(nameof(ShellWeight))]
        [Range(ValidationConstants.ShellWeightMinValue, ValidationConstants.ShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [XmlElement(nameof(Caliber))]
        [MinLength(ValidationConstants.ShellCaliberMinLength)]
        [MaxLength(ValidationConstants.ShellCaliberMaxLength)]
        public string Caliber { get; set; }

    }
}
