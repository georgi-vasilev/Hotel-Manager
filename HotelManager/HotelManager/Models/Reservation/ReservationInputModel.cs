using HotelManager.Data.Entities;
using System;
using System.Collections.Generic;

namespace HotelManager.Models.Reservation
{
    public class ReservationInputModel
    {
        public string RoomId { get; set; }

        public string UserId { get; set; }

        public string Id { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Bills { get; set; }
    }
}
