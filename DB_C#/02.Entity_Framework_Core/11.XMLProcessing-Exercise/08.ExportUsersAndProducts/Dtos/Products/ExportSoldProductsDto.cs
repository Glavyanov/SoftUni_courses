using System.Xml.Serialization;

namespace ProductShop.Dtos.Products
{

    public class ExportSoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportProductWithNamePriceDto[] Products { get; set; }
    }
}
