using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseXmlDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement(nameof(Type))]
        [Required]
        public PurchaseType? Type { get; set; }

        [XmlElement(nameof(Key))]
        [Required]
        [RegularExpression(@"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$")]
        public string Key { get; set; }

        [XmlElement(nameof(Card))]
        [Required]
        [RegularExpression(@"^(\d{4}\s{1}){3}\d{4}$")]
        public string Card { get; set; }

        [XmlElement(nameof(Date))]
        [Required]
        public string Date { get; set; }

    }
}
