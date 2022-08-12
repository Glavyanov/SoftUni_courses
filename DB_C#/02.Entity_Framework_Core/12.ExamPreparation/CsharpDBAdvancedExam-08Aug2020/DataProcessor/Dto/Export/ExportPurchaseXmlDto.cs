using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class ExportPurchaseXmlDto
    {
        [XmlElement(nameof(Card))]
        public string Card { get; set; }

        [XmlElement(nameof(Cvc))]
        public string Cvc { get; set; }

        [XmlElement(nameof(Date))]
        public string Date { get; set; }

        [XmlElement(nameof(Game))]
        public ExportGameXmlDto Game { get; set; }
    }
}
