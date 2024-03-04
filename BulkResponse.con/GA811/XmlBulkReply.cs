using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BulkResponse.con.GA811
{
    [XmlRoot(ElementName = "locateResponses", Namespace = "http://schemas.progressivepartnering.com/geocall/v3/response/v1")]
    public class XmlBulkReply
    {
        [XmlElement(ElementName = "auth")]
        public XmlAuthentication Auth;

        [XmlArray("responses")]
        [XmlArrayItem("response")]
        public List<response> Responses;       
    }

    [XmlRoot(ElementName = "response")]
    public class response
    {
        [XmlElement(ElementName = "ticket")]
        public string Ticket;

        [XmlElement(ElementName = "code")]
        public string Code;

        [XmlElement(ElementName = "facilities")]
        public string Facilities;

        [XmlElement(ElementName = "action")]
        public string Sction;

        [XmlElement(ElementName = "comment")]
        public string Comment;

        [XmlElement(ElementName = "result")]
        public string Result;
    }       
}
