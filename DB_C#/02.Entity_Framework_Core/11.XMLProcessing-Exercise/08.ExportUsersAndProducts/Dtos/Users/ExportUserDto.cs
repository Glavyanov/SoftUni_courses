using System.Xml.Serialization;

namespace ProductShop.Dtos.Users
{

    public class ExportUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; }

    }
}
