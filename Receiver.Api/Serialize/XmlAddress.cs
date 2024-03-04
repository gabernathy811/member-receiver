using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlAddress
    {
        [XmlElement(ElementName = "State")]
        public string State { get; set; }

        [XmlElement(ElementName = "County")]
        public string County { get; set; }

        [XmlElement(ElementName = "City")]
        public string City { get; set; }


        [XmlElement(ElementName = "Street")]
        public XmlStreet Street { get; set; }

        public XmlAddress()
        {
            Street = new XmlStreet();
        }
    }
}
