using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Dtos.CategoryProducts
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDto
    {
        [XmlElement("CategoryId")]
        [Required]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        [Required]
        public int ProductId { get; set; }

    }
}
