using System.Collections.Generic;
using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    [XmlRoot(ElementName = "Ticket", Namespace = "http://www.georgia811.com/geocall/ticket/v1")]
    public class XmlTicket
    { 
        [XmlElement(DataType = "string", ElementName = "OneCallCenter")]
        public string OneCallCenter { get; set; }

        [XmlElement(DataType = "string", ElementName = "TicketNumber")]
        public string TicketNumber { get; set; }

        [XmlElement(DataType = "string", ElementName = "LocateRequestFor")]
        public string LocateRequestFor { get; set; }

        [XmlElement(DataType = "int", ElementName = "SequenceNumber")]
        public int SequenceNumber { get; set; }

        [XmlElement(DataType = "string", ElementName = "PreviousTicketNumber")]
        public string PreviousTicketNumber { get; set; }

        [XmlElement(DataType = "string", ElementName = "TicketType")]
        public string TicketType { get; set; }

        [XmlElement(DataType = "string", ElementName = "TicketSource")]
        public string TicketSource { get; set; }

        [XmlElement(DataType = "string", ElementName = "TicketText")]
        public string TicketText { get; set; }

        [XmlElement(DataType = "string", ElementName = "MeetingLocation")]
        public string MeetingLocation { get; set; }

        [XmlElement(ElementName = "LastResponse")]
        public XmlResponse LastResponse { get; set; }

        [XmlElement(ElementName = "Dates")]
        public XmlDates Dates { get; set; }

        [XmlElement(ElementName = "Excavator")]
        public XmlExcavator Excavator { get; set; }

        [XmlElement(ElementName = "Caller")]
        public XmlCaller Caller { get; set; }

        [XmlElement(ElementName = "FieldContact")]
        public XmlFieldContact FieldContact { get; set; }

        [XmlElement(ElementName = "Work")]
        public XmlWork Work { get; set; }

        [XmlElement(ElementName = "Damage")]
        public XmlDamage Damage { get; set; }

        [XmlArray("Members")]
        [XmlArrayItem("Member")]
        public List<XmlMember> Members { get; set; }

        public XmlTicket()
        {
            LastResponse = new XmlResponse();
            Dates = new XmlDates();
            Excavator = new XmlExcavator();
            Caller = new XmlCaller();
            FieldContact = new XmlFieldContact();
            Work = new XmlWork();
            Damage = new XmlDamage();
            Members = new List<XmlMember>();
        }
    }
}
