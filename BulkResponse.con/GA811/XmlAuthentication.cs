using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BulkResponse.con.GA811
{
    public class XmlAuthentication
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("password")]
        public string Password { get; set; }
    }
}
