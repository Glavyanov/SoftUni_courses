using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckXmlDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        [XmlElement(nameof(RegistrationNumber))]
        public string RegistrationNumber { get; set; }

        [Required]
        [RegularExpression(@"^.{17}$")]
        [XmlElement(nameof(VinNumber))]
        public string VinNumber { get; set; }

        [XmlElement(nameof(TankCapacity))]
        [Range(950,1420)]
        public int TankCapacity { get; set; }

        [XmlElement(nameof(CargoCapacity))]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Range(0,3)]
        [XmlElement(nameof(CategoryType))]
        public int CategoryType { get; set; }

        [Range(0, 4)]
        [XmlElement(nameof(MakeType))]
        public int MakeType { get; set; }
    }
}
