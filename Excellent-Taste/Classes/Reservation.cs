using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellent_Taste.Classes
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Lastname { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string PhoneNum { get; set; }
        public int TableNum { get; set; }
        public string Notes { get; set; }
        public bool Arrived { get; set; }
    }
}
