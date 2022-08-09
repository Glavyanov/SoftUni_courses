using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectXmlDto
    {
        [XmlAttribute(nameof(TasksCount))]
        public int TasksCount { get; set; }

        [XmlElement(nameof(ProjectName))]
        public string ProjectName { get; set; }

        [XmlElement(nameof(HasEndDate))]
        public string HasEndDate { get; set; }


        [XmlArray(nameof(Tasks))]
        public ExportTaskXmlDto[] Tasks { get; set; }
    }
}
