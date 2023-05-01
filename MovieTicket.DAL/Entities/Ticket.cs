using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Status { get; set; }
        public int? Row { get; set; }
        public int? Seat { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        //public DateTime Date { get; set; }
    }
}
