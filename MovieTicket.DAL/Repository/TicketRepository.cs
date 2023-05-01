using Microsoft.EntityFrameworkCore;
using MovieTicket.DAL.EF;
using MovieTicket.DAL.Entities;
using MovieTicket.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.Repository
{
    public class TicketRepository: ITicketRepository
    {
        private MovieContext db;

        public TicketRepository(MovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.Include(o => o.Movie);
        }

        public Ticket GetById(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket ticket)
        {
            db.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }

        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Tickets.Include(o => o.Movie).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket != null)
                db.Tickets.Remove(ticket);
        }


        public IEnumerable<Ticket> GetByMovieId(int id)
        {
            return db.Tickets.Where(t => t.MovieId == id);
        }
    }
}
