using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsXmlDto
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(ValidationConstants.ProjectNameMinLength)]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(OpenDate))]
        [Required]
        public string OpenDate { get; set; }


        [XmlElement(nameof(DueDate))]
        public string DueDate { get; set; }

        [XmlArray(nameof(Tasks))]
        public ImportTaskXmlDto[] Tasks { get; set; }
    }
}
