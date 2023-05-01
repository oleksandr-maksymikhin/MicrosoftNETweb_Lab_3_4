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
    public class MovieRepository : IRepository<Movie>
    {
        private MovieContext db;
        public MovieRepository(MovieContext db)
        {
            this.db = db;
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        //System.ObjectDisposedException - object disposed
        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public IEnumerable<Movie> Find(Func<Movie, Boolean> predicate)
        {
            return db.Movies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);
        }
    }
}
