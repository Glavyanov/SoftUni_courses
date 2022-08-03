using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayXmlDto
    {

        [XmlElement(nameof(Title))]
        [Required]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [XmlElement(nameof(Duration))]
        [Required]
        public string Duration { get; set; }

        [XmlElement(nameof(Rating))]
        [Required]
        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [XmlElement(nameof(Genre))]
        [Required]
        public string Genre { get; set; }

        [XmlElement(nameof(Description))]
        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [XmlElement(nameof(Screenwriter))]
        [Required]
        [MinLength(ValidationConstants.PlayScreeenwriterMinLength)]
        [MaxLength(ValidationConstants.PlayScreeenwriterMaxLength)]
        public string Screenwriter { get; set; }
    }
}
