using Microsoft.EntityFrameworkCore.Metadata;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Game")]
    public class ExportGameXmlDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement(nameof(Genre))]
        public string Genre { get; set; }

        [XmlElement(nameof(Price))]
        public decimal Price { get; set; }
    }
}
