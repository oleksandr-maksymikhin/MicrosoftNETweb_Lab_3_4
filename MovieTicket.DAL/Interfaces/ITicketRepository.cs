using MovieTicket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.Interfaces
{
    public interface ITicketRepository: IRepository<Ticket>
    {
        IEnumerable<Ticket> GetByMovieId(int id);
    }
}
