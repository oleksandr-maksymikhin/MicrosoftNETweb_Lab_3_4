using MovieTicket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Movie> Movies { get; }
        ITicketRepository Tickets { get; }
        void Save();
    }
}
