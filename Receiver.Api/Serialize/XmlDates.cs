using System;
using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlDates
    {
        [XmlElement(DataType = "dateTime", ElementName = "CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [XmlElement(DataType = "string", ElementName = "RespondBy")]
        public string RespondBy { get; set; }

        [XmlElement(DataType = "string", ElementName = "RespondBy30")]
        public string RespondBy30 { get; set; }

        [XmlElement(DataType = "string", ElementName = "RespondBy60")]
        public string RespondBy60 { get; set; }

        [XmlElement(DataType = "string", ElementName = "RespondBy90")]
        public string RespondBy90 { get; set; }

        [XmlElement(DataType = "string", ElementName = "LegalOn")]
        public string LegalOn { get; set; }

        [XmlElement(DataType = "string", ElementName = "UpdateableOn")]
        public string UpdateableOn { get; set; }

        [XmlElement(DataType = "string", ElementName = "UpdateBy")]
        public string UpdateBy { get; set; }

        [XmlElement(DataType = "string", ElementName = "ExpiresOn")]
        public string ExpiresOn { get; set; }

        [XmlElement(DataType = "string", ElementName = "CommenceOn")]
        public string CommenceOn { get; set; }

        [XmlElement(DataType = "string", ElementName = "CompletedBy")]
        public string CompletedBy { get; set; }

        [XmlElement(DataType = "string", ElementName = "MeetingDate")]
        public string MeetingDate { get; set; }

        [XmlElement(DataType = "dateTime", ElementName = "TransmittedOn")]
        public DateTime TransmittedOn { get; set; }
    }
}
