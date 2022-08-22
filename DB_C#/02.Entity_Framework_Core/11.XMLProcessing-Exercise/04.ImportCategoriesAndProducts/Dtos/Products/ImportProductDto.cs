using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Products
{
    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement("name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [XmlElement("price")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }

    }
}
