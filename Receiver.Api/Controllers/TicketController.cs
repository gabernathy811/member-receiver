using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Receiver.Api.Entities;
using Receiver.Api.Serialize;
using Receiver.Api.Services;
using System;
using System.Threading.Tasks;

namespace Receiver.Api.Controllers
{
    
    [Route("api/ticket")]
    [ApiController]
    // Inherit from controller base for API's
    public class TicketController : ControllerBase 
    {
        private ITicketRepository _ticketRepository;
        
        public TicketController(ITicketRepository ticketRespository)
        {
            _ticketRepository = ticketRespository ?? throw new ArgumentNullException(nameof(ticketRespository));
        }        

        // This method attempts to deserialize the xml body of the post 
        // into the xml object structure in the Serialize folder, starting 
        // with the XmlTicket type
        [HttpPost]
        public async Task<IActionResult> CreateTicket(XmlTicket xmlTicket)
        {
            // create a new db entity class for an incoming GA 811 ticket
            IncomingTicket ticket = new IncomingTicket();
            // this method copies the data from the XmlTicket object 
            // into the EF Core object
            ticket.CopyFromXml(xmlTicket);

            // Add the new EF Core object into the repository for "tracking" as a new inserted item
            _ticketRepository.AddTicket(ticket);           

            // Save to the database asynchronously
            // The SaveChangesAsync returns true if the change committed
            if (await _ticketRepository.SaveChangesAsync())
            {
                return Ok();
            }
            else
            {
                // If this did notcommit to the DB, return an error.  GA 811 will 
                // then know that the ticket was notreceived successfully, and will 
                // re-try transmission later                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        

    }
}
