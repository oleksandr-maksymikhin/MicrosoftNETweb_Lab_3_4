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
    public class EFUnitOfWork : IUnitOfWork
    {
        private MovieContext db;
        private MovieRepository movieRepository;
        private TicketRepository ticketRepository;

        //public EFUnitOfWork (DbContextOptions<MovieContext> options)
        //{
        //    db = new MovieContext(options);
        //}

        public EFUnitOfWork(MovieContext dbContext)
        {
            db = dbContext;
        }


        public IRepository<Movie> Movies
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new MovieRepository(db);
                }
                return movieRepository;
            }
        }

        public ITicketRepository Tickets
        {
            get
            {
                if (ticketRepository == null)
                {
                    ticketRepository = new TicketRepository(db);
                }
                return ticketRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        //dispose - unmanaged resourses of DB connections
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
