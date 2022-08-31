using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos
{
    [XmlType("partId")]
    public class ImportCarPartIDDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }

    }
}
