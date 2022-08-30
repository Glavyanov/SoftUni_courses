using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Users
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
