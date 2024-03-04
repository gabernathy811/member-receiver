using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BulkResponse.con.GA811
{
    public class BulkReply
    {
        public XmlBulkReply Reply;

        public BulkReply(HttpContent responseContent)
        {
            var serializer = new XmlSerializer(typeof(XmlBulkReply));
            Reply = (XmlBulkReply)serializer.Deserialize(ReadStream(responseContent));
        }

        // Helper function to read the response stream
        private Stream ReadStream(HttpContent content)
        {
            Task<Stream> ts = content.ReadAsStreamAsync();
            return ts.Result;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (response r in Reply.Responses)
            {
                sb.AppendLine($"Ticket: {r.Ticket} SA Code: {r.Code} Facilities: {r.Facilities} Resp Code: {r.Sction} Comment: {r.Comment}");
                sb.AppendLine(r.Result);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
