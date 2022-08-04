using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class ExportPlayXmlDto
    {
        [XmlAttribute(nameof(Title))]
        public string Title { get; set; }

        [XmlAttribute(nameof(Duration))]
        public string Duration { get; set; }

        [XmlAttribute(nameof(Rating))]
        public string Rating { get; set; }

        [XmlAttribute(nameof(Genre))]
        public string Genre { get; set; }

        [XmlArray(nameof(Actors))]
        public ExportActorXmlDto[] Actors { get; set; }
    }
}
