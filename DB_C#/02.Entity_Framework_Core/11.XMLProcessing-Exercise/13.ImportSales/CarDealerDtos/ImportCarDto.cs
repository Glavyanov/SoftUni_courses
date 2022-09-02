using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement(nameof(TraveledDistance))]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        [NotMapped]
        public ImportCarPartIDDto[] Parts { get; set; }

    }
}
