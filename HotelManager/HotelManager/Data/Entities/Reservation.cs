using System;
using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientReservations = new HashSet<ClientReservation>();
        }

        public string RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string UserId { get; set; }
        public virtual User Employee { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }


        public string Id { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Bills { get; set; }
    }
}
