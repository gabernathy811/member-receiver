using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlPhoneNumber
    {
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Number")]
        public string Number { get; set; }

        [XmlElement("Extension")]
        public string Extension { get; set; }
    }
}
