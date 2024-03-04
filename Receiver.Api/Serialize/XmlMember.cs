using System.Collections.Generic;
using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlMember
    {
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "FacilityType")]
        public string FacilityType { get; set; }

        [XmlArray("PhoneNumbers")]
        [XmlArrayItem("PhoneNumber")]
        public List<XmlPhoneNumber> PhoneNumbers { get; set; }

        public XmlMember()
        {
            PhoneNumbers = new List<XmlPhoneNumber>();
        }
    }
}
