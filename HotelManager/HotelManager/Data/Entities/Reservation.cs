using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Data.Entities
{
    public class Reservation
    {
        public int ReservedRoomId { get; set; }

        public int ClientReservator { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public decimal Bills { get; set; }
    }
}
