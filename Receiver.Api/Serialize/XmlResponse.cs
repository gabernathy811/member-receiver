using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlResponse
    {
        [XmlElement(DataType = "string", ElementName = "Code")]
        public string Code { get; set; }

        [XmlElement(DataType = "string", ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(DataType = "string", ElementName = "Comment")]
        public string Comment { get; set; }
    }
}
