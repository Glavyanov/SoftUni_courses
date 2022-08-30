using ProductShop.Dtos.Products;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Users
{
    [XmlType("User")]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement(nameof(SoldProducts))]
        public ExportSoldProductsDto SoldProducts { get; set; }
    }
}
