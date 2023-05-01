using MovieTicket.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.Interfaces
{
    public interface IMovieService
    {
        MovieDTO GetMovieById(int? id);
        IEnumerable<MovieDTO> GetMovies();
        IEnumerable<MovieDTO> SearchMovies(string search);
        void AddMovie(MovieDTO movieDto);
        void Dispose();
    }
}
