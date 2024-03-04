using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlWork
    {
        [XmlElement(DataType = "string", ElementName = "WorkType")]
        public string WorkType { get; set; }

        [XmlElement(DataType = "string", ElementName = "DoneFor")]
        public string DoneFor { get; set; }

        [XmlElement(DataType = "string", ElementName = "Explosives")]
        public string Explosives { get; set; }

        [XmlElement(DataType = "string", ElementName = "DirectionalBoring")]
        public string DirectionalBoring { get; set; }

        [XmlElement(DataType = "string", ElementName = "WhitePaint")]
        public string WhitePaint { get; set; }

        [XmlElement(DataType = "int", ElementName = "WhitePaintCount")]
        public int WhitePaintCount { get; set; }

        [XmlElement(DataType = "string", ElementName = "Duration")]
        public string Duration { get; set; }

        [XmlElement(DataType = "string", ElementName = "ScopeOfWork")]
        public string ScopeOfWork { get; set; }

        [XmlElement(DataType = "string", ElementName = "CrossStreet")]
        public string CrossStreet { get; set; }

        [XmlElement(DataType = "string", ElementName = "DigsiteWKT")]
        public string DigsiteWKT { get; set; }

        [XmlElement(DataType = "string", ElementName = "LocateInstructions")]
        public string LocateInstructions { get; set; }

        [XmlElement(DataType = "string", ElementName = "Remarks")]
        public string Remarks { get; set; }

        [XmlElement(DataType = "string", ElementName = "MeetingLocation")]
        public string MeetingLocation { get; set; }

        [XmlElement(ElementName = "Address")]
        public XmlAddress Address { get; set; }

        public XmlWork()
        {
            Address = new XmlAddress();
        }
    }
}
