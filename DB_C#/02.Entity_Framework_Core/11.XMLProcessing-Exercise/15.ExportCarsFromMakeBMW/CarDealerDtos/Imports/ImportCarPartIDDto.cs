using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos.Imports
{
    [XmlType("partId")]
    public class ImportCarPartIDDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }

    }
}
