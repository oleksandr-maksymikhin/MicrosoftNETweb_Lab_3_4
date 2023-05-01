using Microsoft.EntityFrameworkCore;
using MovieTicket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.EF
{
    public class MovieContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //public MovieContext(DbContextOptions<MovieContext> options) : base()
        //{
        //    Database.EnsureCreated();
        //}

        public MovieContext()
        {
            Database.EnsureCreated();
        }

        public MovieContext(DbContextOptions<MovieContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=LENOVOG500;Database=PhoneOrderTestLab3MVC;Trusted_Connection=True;TrustServerCertificate=True");
        //}


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BuildDateFields(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 100,
                Title = "Interstellar",
                Director = "Christopher Nolan",
                Genre = "Fantasy",
                Date = new DateTime(2023,01,01)
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket()
            {
                Id = 200,
                MovieId = 100,
                Price = 500,
                Status = "open",
                Row = 1,
                Seat = 1
                
            });
        }*/


        //protected void BuildDateFields(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ticket>()
        //        .Property(entity => entity.Date)
        //        .HasDefaultValueSql("getdate()");
        //}

    }

}
