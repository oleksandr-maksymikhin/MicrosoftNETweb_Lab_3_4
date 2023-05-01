using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.BLL.Interfaces;
using MovieTicket.BLL.DTO;
using AutoMapper;
using MovieTicket.PL.Models;
using MovieTicket.BLL.Infrastructure;
using MovieTicket.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MovieTicket.PL.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketService ticketService;
        private IMovieService movieService;
        IMapper mapper;

        public TicketsController(ITicketService ticketService, IMovieService movieService)
        {
            this.ticketService = ticketService;
            this.movieService = movieService;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>().ReverseMap()).CreateMapper();
        }


        // GET: Tickets
        public ActionResult Index()
        {
            IEnumerable<TicketDTO> ticketDtos = ticketService.GetTickets();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
            var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
            return View(tickets);
        }

        // GET: Tickets/IndexByMovieId/5
        public ActionResult IndexByMovieId(int id)
        {
            IEnumerable<TicketDTO> ticketDtos = ticketService.GetTicketsByMovieId(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
            var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);

            MovieDTO movieTdo = movieService.GetMovieById(id);
            ViewBag.MovieTitle = movieTdo.Title;
            return View(tickets);
        }

        // GET: Tickets/BookTicket
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult BookTicket(int ticketId)
        {
            try
            {
                TicketDTO bookTicketDto = ticketService.GetTicketById(ticketId);
                int movieId = 0;
                if (bookTicketDto != null)
                {
                    ticketService.BookTicket(ticketId);
                    movieId = bookTicketDto.MovieId;
                }

                return RedirectToAction(nameof(IndexByMovieId), new { id = movieId });
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: TicketsController/ByTicket
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult BuyTicket(int ticketId)
        {
            try
            {
                TicketDTO bookTicketDto = ticketService.GetTicketById(ticketId);
                int movieId = 0;
                if (bookTicketDto != null)
                {
                    ticketService.BuyTicket(ticketId);
                    movieId = bookTicketDto.MovieId;
                }

                return RedirectToAction(nameof(IndexByMovieId), new { id = movieId });
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: TicketsController/Create
        public ActionResult Create()
        {
            ViewBag.Movies = new SelectList(movieService.GetMovies().OrderBy(mapper => mapper.Title), "Id", "Title");
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel ticketViewModel)
        {
            for(int i = 0; i < ticketViewModel.Row; i++)
            {
                for(int j = 0; j < ticketViewModel.Seat; j++)
                {
                    TicketViewModel ticketViewModelCreate = new TicketViewModel()
                    {
                        Id = 0,
                        MovieId = ticketViewModel.MovieId,
                        Price = ticketViewModel.Price,
                        SalePrice = 0,
                        Status = "open",
                        Row = i + 1,
                        Seat = j + 1
                    };
                    TicketDTO ticketDtoCreate = mapper.Map<TicketViewModel, TicketDTO>(ticketViewModelCreate);
                    ticketService.MakeTicket(ticketDtoCreate);
                }
            }
            return RedirectToAction(nameof(Create));
        }


        // GET: TicketsController/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }*/


        // GET: TicketsController/Edit/5
        /*        public ActionResult Edit(int id)
                {
                    return View();
                }*/

        // POST: TicketsController/Edit/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: TicketsController/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: TicketsController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
