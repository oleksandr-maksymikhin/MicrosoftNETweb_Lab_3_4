using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.BusinessModels
{
    public class DiscountValue
    {
        private decimal value = 0;
        private DateTime date;
        public decimal Value { get { return value; } }
        public DiscountValue(decimal value, DateTime date)
        {
            this.value = value;
            this.date = date;
        }
        public decimal GetDiscountedPrice()
        {
            if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday)
            {
                value = 0.5m * value;
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Thursday)
            {
                value = 0.8m * value;
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                value = 0.9m * value;
            }
            return Value;
        }
    }
}
