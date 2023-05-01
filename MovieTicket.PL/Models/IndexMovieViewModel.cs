namespace MovieTicket.PL.Models
{
    public class IndexMovieViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; }
        public MoviePageViewModel MoviePageViewModel { get; }
        public MovieFilterViewModel MovieFilterViewModel { get; }
        public MovieSortViewModel MovieSortViewModel { get; }

        public IndexMovieViewModel (IEnumerable<MovieViewModel> movies,
            MoviePageViewModel moviePageViewModel,
            MovieFilterViewModel movieFilterViewModel,
            MovieSortViewModel movieSortViewModel)
        {
            Movies = movies;
            MoviePageViewModel = moviePageViewModel;
            MovieFilterViewModel = movieFilterViewModel;
            MovieSortViewModel = movieSortViewModel;
        }

    }
}
