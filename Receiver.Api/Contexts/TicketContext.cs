using Microsoft.EntityFrameworkCore;
using Receiver.Api.Entities;

namespace Receiver.Api.Contexts
{
    public class TicketContext : DbContext
    {
        public DbSet<IncomingTicket> Tickets { get; set; }

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {

        }
    }
}
