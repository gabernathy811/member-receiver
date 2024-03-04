using System.Threading.Tasks;

namespace Receiver.Api.Services
{
    public interface ITicketRepository
    {        
        void AddTicket(Entities.IncomingTicket ticket);

        Task<bool> SaveChangesAsync();

    }
}
