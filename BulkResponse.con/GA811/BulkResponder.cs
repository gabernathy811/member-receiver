using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BulkResponse.con.GA811
{    
    public class BulkResponder
    {
        // The GA811 system uses this name space for bulk responses
        private string XmlResponseNS = "http://schemas.progressivepartnering.com/geocall/v3/response/v1";

        private List<TicketResponse> _responses;
        private string _user;
        private string _password;
        
        public BulkResponder(string user, string password)
        {
            _user = user;
            _password = password;
            _responses = new List<TicketResponse>();
        }

        // Add a ticket response
        // code = Service Area Code responding for
        // ticket = Ticket Number
        // comment = Comments for the response
        // facilities = Facility type responding for (Water, Sewer, etc.)
        // action = Response Code (1A, 1B, 1C...etc.)
        public void AddResponse(string code, string ticket, string comment, string facilities, string action)
        {
            var resp = new TicketResponse();

            resp.Code = code;
            resp.Ticket = ticket;
            resp.Comment = comment;
            resp.Facilities = facilities;
            resp.Action = action;

            _responses.Add(resp);
        }

        // Send the responses
        public async Task<BulkReply> Send(string serverUri)
        {
            if (_responses.Count > 0)
            {
                // Send over Http
                using (var httpClient = new HttpClient())
                {
                    // Add the xml as string content, use MIME type text/xml
                    string xmlDocString = this.ToXml(XmlResponseNS);
                    StringContent content = new StringContent(xmlDocString, Encoding.UTF8, "text/xml");

                    // Process the Http response
                    using (var response = await httpClient.PostAsync(serverUri, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            // If the API call was successful, a Reply document will be returned
                            // containing a 'result' string for every TicketResponse submitted
                            return new BulkReply(response.Content);
                        }
                        else
                        {
                            throw new ApplicationException($"GA811 responded with {response.StatusCode}");
                        }
                    }
                }
            }
            else
            {
                throw new ApplicationException("No responses have been added to the BulkResponder");
            }
        }

        // This utilizes and XmlWriter to privide greater control over
        // specific XML needed to generate for the Bulk Response API        
        private string ToXml(string nameSpace)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8
            };

            using (StringWriter stringWriter = new StringWriterUTF8())
            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("locateResponses", nameSpace);

                writer.WriteStartElement("auth");
                writer.WriteAttributeString("user", _user);
                writer.WriteAttributeString("password", _password);
                writer.WriteEndElement();

                writer.WriteStartElement("responses");
                foreach (TicketResponse r in _responses)
                {
                    writer.WriteStartElement("response");
                    writer.WriteElementString("ticket", r.Ticket);
                    writer.WriteElementString("code", r.Code);
                    writer.WriteElementString("facilities", r.Facilities);
                    writer.WriteElementString("action", r.Action);
                    writer.WriteElementString("comment", r.Comment);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();

                return stringWriter.ToString();
            }
        }
    }
}
