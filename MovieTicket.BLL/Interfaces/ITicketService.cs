using MovieTicket.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.Interfaces
{
    public interface ITicketService
    {
        void MakeTicket(TicketDTO ticketDto);
        //MovieDTO GetMovie(int? id);
        //IEnumerable<MovieDTO> GetMovies();
        TicketDTO GetTicketById(int? id);
        IEnumerable<TicketDTO> GetTickets();
        IEnumerable<TicketDTO> GetTicketsByMovieId(int id);
        void BookTicket(int id);
        void BuyTicket(int id);
        void Dispose();
    }
}
