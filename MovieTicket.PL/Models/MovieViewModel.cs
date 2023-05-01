namespace MovieTicket.PL.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string? Poster { get; set; }
        public DateTime Date { get; set; }
    }
}
