using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherXmlDto
    {
        [XmlAttribute(nameof(TrucksCount))]
        public int TrucksCount { get; set; }

        [XmlElement(nameof(DespatcherName))]
        public string DespatcherName { get; set; }

        [XmlArray(nameof(Trucks))]
        public ExportTruckXmlDto[] Trucks { get; set; }
    }
}
