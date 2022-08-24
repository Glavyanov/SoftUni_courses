using ProductShop.Dtos.Products;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Users
{
    [XmlType("User")]
    public class ExportUserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportProductSoldProductsDto[] SoldProducts { get; set; }

    }
}
