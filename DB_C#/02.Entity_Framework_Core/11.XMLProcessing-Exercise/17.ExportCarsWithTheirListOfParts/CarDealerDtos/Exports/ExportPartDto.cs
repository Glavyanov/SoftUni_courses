using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos.Exports
{
    [XmlType("part")]
    public class ExportPartDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
