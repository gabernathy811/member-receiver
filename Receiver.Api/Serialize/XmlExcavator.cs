using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlExcavator
    {
        [XmlElement(DataType = "string", ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(DataType = "string", ElementName = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement(DataType = "string", ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(DataType = "string", ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(DataType = "string", ElementName = "City")]
        public string City { get; set; }

        [XmlElement(DataType = "string", ElementName = "State")]
        public string State { get; set; }

        [XmlElement(DataType = "string", ElementName = "ZIPCode")]
        public string ZIPCode { get; set; }
    }
}
