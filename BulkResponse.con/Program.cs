using System;
using System.Threading.Tasks;

namespace BulkResponse.con
{
    class Program
    {       
        static string GA811ServerURI = "https://member.geocall.ga811.com/geocall/api/app/response/bulk";
        static async Task Main(string[] args)
        {

            // Create a new BulkResponder and set the username and password (provided by GA811)
            //var Responder = new GA811.BulkResponder("XYZ99Responder", "SecretPassword");

            // Add some ticket responses
            //Responder.AddResponse("XYZ99", "200227-001005", "PRIS Response Comment", "Water", "1A");
            //Responder.AddResponse("XYZ99", "200227-001017", "PRIS Response Comment", "Water", "1A");

            // Send the responses and store the batch reply
            //var reply = await Responder.Send(GA811ServerURI);

            // dump the batch replies to the console
            Console.WriteLine(DateTime.Now.AddDays(-1).ToShortDateString());
            //Console.WriteLine(reply.ToString());
            Console.ReadLine();
        }
    }
}
