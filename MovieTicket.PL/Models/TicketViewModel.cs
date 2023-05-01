namespace MovieTicket.PL.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
        public int SalePrice { get; set; }
        public string Status { get; set; }
        public int? Row { get; set; }
        public int? Seat { get; set; }

    }
}
