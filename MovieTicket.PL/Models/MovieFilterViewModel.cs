namespace MovieTicket.PL.Models
{
    public class MovieFilterViewModel
    {
        public string Search { get; }
        public MovieFilterViewModel(string search)
        {
            Search = search;
        }
    }
}
