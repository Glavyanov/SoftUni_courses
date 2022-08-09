using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskXmlDto
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(ValidationConstants.TaskNameMinLength)]
        [MaxLength(ValidationConstants.TaskNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(OpenDate))]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement(nameof(DueDate))]
        [Required]
        public string DueDate { get; set; }

        [XmlElement(nameof(ExecutionType))]
        [Required]
        public string ExecutionType { get; set; }

        [XmlElement(nameof(LabelType))]
        [Required]
        public string LabelType { get; set; }
    }
}
