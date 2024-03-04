using System.IO;
using System.Text;

namespace BulkResponse.con
{
    // The default StringWriter encondes to UTF16
    // This allows us to cteate a StringWriter that encodes to UTF8
    // for XML
    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
