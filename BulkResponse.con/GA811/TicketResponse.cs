using System.Xml.Serialization;

namespace BulkResponse.con.GA811
{    
    public class TicketResponse
    {
        [XmlElement(ElementName = "ticket")]
        public string Ticket { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "facilities")]
        public string Facilities { get; set; }

        [XmlElement(ElementName = "action")]
        public string Action { get; set; }

        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }

        [XmlElement(ElementName = "result")]
        public string Result { get; set; }
    }
}
