using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlStreet
    {
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }

        [XmlElement(ElementName = "Prefix")]
        public string Prefix { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Suffix")]
        public string Suffix { get; set; }
    }
}

