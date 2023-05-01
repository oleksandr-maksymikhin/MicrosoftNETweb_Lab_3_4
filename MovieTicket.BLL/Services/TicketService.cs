using AutoMapper;
using MovieTicket.BLL.BusinessModels;
using MovieTicket.BLL.DTO;
using MovieTicket.BLL.Infrastructure;
using MovieTicket.BLL.Interfaces;
using MovieTicket.DAL.Entities;
using MovieTicket.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;
        public TicketService(IUnitOfWork uow)
        {
            Database = uow;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>().ReverseMap()).CreateMapper();
        }

        public void MakeTicket(TicketDTO ticketDto)
        {
            //Movie movie = Database.Movies.GetById(ticketDto.MovieId);

            // валидация
            /*if (movie == null)
                throw new ValidationException("Movie not found", "");*/
            // применяем скидку
            //decimal sum = new DiscountValue(0.1m).GetDiscountedPrice(ticketDto.Price);
            /*            Ticket ticket = new Ticket
                        {
                            MovieId = movie.Id,
                            Price = sum,
                            Status = ticketDto.Status,
                            Row = ticketDto.Row,
                            Seat = ticketDto.Seat,
                        };*/
            Ticket ticket = mapper.Map<TicketDTO, Ticket>(ticketDto);
            Database.Tickets.Create(ticket);
            Database.Save();
        }

        public TicketDTO GetTicketById(int? id)
        {
            if (id == null)
                throw new ValidationException("No ID for the ticket", "");
            var ticket = Database.Tickets.GetById(id.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            return new TicketDTO
            {
                Id = ticket.Id,
                MovieId = ticket.MovieId,
                Price = ticket.Price,
                Status = ticket.Status,
                Row = ticket.Row,
                Seat = ticket.Seat
            };
        }

        public IEnumerable<TicketDTO> GetTickets()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.GetAll());
        }

        public IEnumerable<TicketDTO> GetTicketsByMovieId(int id)
        {

            if (id == null)
            {
                throw new ValidationException("Movie Id is not defined", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            List<TicketDTO> ticketDtos = mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.GetByMovieId(id));
            return ticketDtos;
        }

        public void BookTicket(int id)
        {
            Ticket ticket = Database.Tickets.GetById(id);
            if (ticket.Status == "open")
            {
                ticket.Status = "booked";
            }
            else
            {
                throw new ValidationException("Ticket is not open", "");
            }
            Database.Tickets.Update(ticket);
            Database.Save();
        }
        public void BuyTicket(int id)
        {
            Ticket ticket = Database.Tickets.GetById(id);
            DateTime movieDate = Database.Movies.GetById(ticket.MovieId).Date;
            if (ticket.Status == "open" || ticket.Status == "booked")
            {
                ticket.Status = "sold";
                ticket.SalePrice = new DiscountValue(ticket.Price, movieDate).GetDiscountedPrice();
            }
            else
            {
                throw new ValidationException("Ticket is sold", "");
            }
            Database.Tickets.Update(ticket);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }



        /*        public MovieDTO GetMovie(int? id)
                {
                    if (id == null)
                        throw new ValidationException("No ID for the movie", "");
                    var movie = Database.Movies.GetById(id.Value);
                    if (movie == null)
                        throw new ValidationException("Movie not found", "");

                    return new MovieDTO
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Director = movie.Director,
                        Genre = movie.Genre,
                        Poster = movie.Poster,
                        Date = movie.Date
                    };
                }*/


        /*        public IEnumerable<MovieDTO> GetMovies()
                {
                    // применяем автомаппер для проекции одной коллекции на другую
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()).CreateMapper();
                    return mapper.Map<IEnumerable<Movie>, List<MovieDTO>>(Database.Movies.GetAll());
                }*/


    }
}
