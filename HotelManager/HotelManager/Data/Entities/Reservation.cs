using System;
using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            this.ReservedRooms = new HashSet<Room>();
            this.ReservationId = Guid.NewGuid().ToString();
            this.Guests = new HashSet<Client>();
        }

        public string ReservationId { get; private set; }

        public virtual ICollection<Room> ReservedRooms{ get; set; }

        public User UserReservator { get; set; }
        
        public virtual ICollection<Client> Guests { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public decimal Bills { get; set; }
    }
}
