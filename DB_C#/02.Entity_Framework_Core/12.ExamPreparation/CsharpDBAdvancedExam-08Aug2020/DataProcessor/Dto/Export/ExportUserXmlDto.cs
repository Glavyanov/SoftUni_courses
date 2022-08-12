using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUserXmlDto
    {
        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchaseXmlDto[] Purchases { get; set; }

        [XmlElement(nameof(TotalSpent))]
        public decimal TotalSpent { get; set; }
    }
}
