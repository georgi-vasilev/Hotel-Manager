using System;
using System.Collections.Generic;
using HotelManager.Data.Entities;

namespace HotelManager.Models.Reservation
{
    public class ReservationDetailsViewModel
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Bills { get; set; }
    }
}
