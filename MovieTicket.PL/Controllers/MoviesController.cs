using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTicket.BLL.DTO;
using MovieTicket.BLL.Infrastructure;
using MovieTicket.BLL.Interfaces;
using MovieTicket.PL.Models;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace MovieTicket.PL.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private IMovieService movieService;
        private IMapper mapper;

        public MoviesController(ILogger<MoviesController> logger, IMovieService movieServ)
        {
            _logger = logger;
            movieService = movieServ;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>().ReverseMap()).CreateMapper();
        }

        // GET: Movies
        public ActionResult Index(string? search, SortState sortOrder = SortState.TitleAsc, int page = 1, int pageSize = 3)
        {
            IEnumerable<MovieDTO> movieDtos = movieService.GetMovies();
            

            //filtering
            if (!string.IsNullOrEmpty(search))
            {
                movieDtos = movieDtos.Where(m => m.Title.Contains(search)
                                                || m.Genre.Contains(search)
                                                || m.Title.Contains(search));
            }
            ViewBag.SearchValue = search;

            //sorting
            switch (sortOrder)
            {
                case SortState.TitleAsc:
                    movieDtos = movieDtos.OrderBy(m => m.Title);
                    break;
                case SortState.TitleDesc:
                    movieDtos = movieDtos.OrderByDescending(m => m.Title);
                    break;
                case SortState.DirectorAsc:
                    movieDtos = movieDtos.OrderBy(m => m.Director);
                    break;
                case SortState.DirectorDesc:
                    movieDtos = movieDtos.OrderByDescending(m => m.Director);
                    break;
                case SortState.GenreAsc:
                    movieDtos = movieDtos.OrderBy(m => m.Genre);
                    break;
                case SortState.GenreDesc:
                    movieDtos = movieDtos.OrderByDescending(m => m.Genre);
                    break;
                case SortState.DateAsc:
                    movieDtos = movieDtos.OrderBy(m => m.Date);
                    break;
                case SortState.DateDesc:
                    movieDtos = movieDtos.OrderByDescending(m => m.Date);
                    break;
            }

            //paging
            //int pageSize = 3;
            int count = movieDtos.Count();
            List<MovieDTO> movieDtosToView = movieDtos.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()).CreateMapper();
            List<MovieViewModel> movies = mapper.Map<IEnumerable<MovieDTO>, List<MovieViewModel>>(movieDtosToView);

            IndexMovieViewModel indexMovieViewModel = new IndexMovieViewModel(
                movies,
                new MoviePageViewModel(count, page, pageSize),
                new MovieFilterViewModel(search),
                new MovieSortViewModel(sortOrder)
                );

            return View(indexMovieViewModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Poster,Id,Title,Director,Genre,Date")] MovieViewModel movieViewModel)
        public IActionResult Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                MovieDTO movieDTO = mapper.Map<MovieViewModel, MovieDTO>(movieViewModel);
                movieService.AddMovie(movieDTO);
                return RedirectToAction(nameof(Create));
            }
            return View(movieViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            movieService.Dispose();
            base.Dispose(disposing);
        }
    }
}