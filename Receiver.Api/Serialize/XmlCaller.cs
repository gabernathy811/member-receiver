using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlCaller
    {
        [XmlElement(DataType = "string", ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(DataType = "string", ElementName = "Phone")]
        public string Phone { get; set; }

        [XmlElement(DataType = "string", ElementName = "PhoneExtension")]
        public string PhoneExtension { get; set; }

        [XmlElement(DataType = "string", ElementName = "Email")]
        public string Email { get; set; }
    }
}
