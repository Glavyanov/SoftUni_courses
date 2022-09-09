using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.CarDealerDtos.Imports
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        [Required]
        public DateTime? BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
