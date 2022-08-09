using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class ExportTaskXmlDto
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; }

        [XmlElement(nameof(Label))]
        public string Label { get; set; }
    }
}
