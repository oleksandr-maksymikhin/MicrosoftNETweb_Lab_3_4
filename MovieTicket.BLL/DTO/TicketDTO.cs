using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Status { get; set; }
        public int? Row { get; set; }
        public int? Seat { get; set; }

        //public DateTime? Date { get; set; }
    }
}
