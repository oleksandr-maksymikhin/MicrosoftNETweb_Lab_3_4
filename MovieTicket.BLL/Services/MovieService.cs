using AutoMapper;
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
    public class MovieService: IMovieService
    {
        private IUnitOfWork Database { get; set; }
        private IMapper mapper;
        public MovieService(IUnitOfWork uow)
        {
            Database = uow;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>().ReverseMap()).CreateMapper();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Movie>, List<MovieDTO>>(Database.Movies.GetAll());
        }

        public IEnumerable<MovieDTO> SearchMovies(string search)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()).CreateMapper();
            List<MovieDTO> searchMovieDtos= mapper.Map<IEnumerable<Movie>, List<MovieDTO>>
                (Database.Movies.GetAll().Where(m => m.Title.Contains(search) 
                                                || m.Genre.Contains(search) 
                                                || m.Title.Contains(search)));
            return searchMovieDtos;
        }

        public MovieDTO GetMovieById(int? id)
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
        }

        public void AddMovie(MovieDTO movieDto)
        {
            if (movieDto != null)
            {
                Movie movie = mapper.Map<MovieDTO, Movie>(movieDto);
                Database.Movies.Create(movie);
                Database.Save();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
