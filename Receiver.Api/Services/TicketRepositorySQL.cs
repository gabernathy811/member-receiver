using Receiver.Api.Contexts;
using Receiver.Api.Entities;
using System;
using System.Threading.Tasks;

namespace Receiver.Api.Services
{
    public class TicketRepositorySql : ITicketRepository
    {
        private TicketContext _context;

        public TicketRepositorySql(TicketContext ticketContext)
        {
            // if the DbContext is null, throw an exception            
            _context = ticketContext ?? throw new ArgumentNullException(nameof(ticketContext));
        }

        // Add the ticket
        public void AddTicket(IncomingTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            _context.Add(ticket);
        }

        // Commit any added tickets to the database
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

    }
}
