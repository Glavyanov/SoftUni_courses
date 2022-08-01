using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunXmlDto
    {
        [XmlAttribute("Manufacturer")]
        public string ManufacturerName { get; set; }

        [XmlAttribute(nameof(GunType))]
        public string GunType { get; set; }

        [XmlAttribute(nameof(GunWeight))]
        public int GunWeight { get; set; }

        [XmlAttribute(nameof(BarrelLength))]
        public double BarrelLength { get; set; }

        [XmlAttribute(nameof(Range))]
        public int Range { get; set; }

        [XmlArray(nameof(Countries))]
        public ExportCountryXmlDto[] Countries { get; set; }
    }
}
