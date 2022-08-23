using System.Xml.Serialization;

namespace ProductShop.Dtos.Products
{
    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string BuyerFullName { get; set; }

        public bool ShouldSerializeBuyerFullName() => this.BuyerFullName != null;
    }
}
