using System.Xml.Serialization;

namespace ProductShop.Dtos.Categories
{
    [XmlType("Category")]
    public class ExportCategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }

    }
}
