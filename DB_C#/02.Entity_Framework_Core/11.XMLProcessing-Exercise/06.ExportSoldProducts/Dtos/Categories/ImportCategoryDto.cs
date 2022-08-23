using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Categories
{
    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [XmlElement("name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
