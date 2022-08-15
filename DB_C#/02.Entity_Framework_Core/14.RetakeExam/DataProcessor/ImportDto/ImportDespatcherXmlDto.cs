using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherXmlDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement(nameof(Name))]
        public string Name { get; set; }

        [XmlElement(nameof(Position))]
        [Required(AllowEmptyStrings = false)]

        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportTruckXmlDto[] Trucks { get; set; }
    }
}
