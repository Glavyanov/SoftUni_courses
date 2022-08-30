using System.Xml.Serialization;

namespace ProductShop.Dtos.Products
{
    [XmlType("Product")]
    public class ExportProductSoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
