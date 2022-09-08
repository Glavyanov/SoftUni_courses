using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos.Exports
{
    [XmlType("car")]
    public class ExportCarWithPartsDto
    {

        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartDto[] Parts { get; set; }
    }
}
