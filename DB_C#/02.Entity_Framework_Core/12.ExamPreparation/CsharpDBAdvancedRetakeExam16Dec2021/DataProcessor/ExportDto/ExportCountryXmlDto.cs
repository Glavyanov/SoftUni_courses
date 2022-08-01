using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportCountryXmlDto
    {
        [XmlAttribute(nameof(Country))]
        public string Country { get; set; }

        [XmlAttribute(nameof(ArmySize))]
        public int ArmySize { get; set; }
    }
}
