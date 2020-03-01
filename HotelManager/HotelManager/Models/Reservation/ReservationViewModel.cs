using HotelManager.Data.Entities;
using System;
using System.Collections.Generic;

namespace HotelManager.Models.Reservation
{
    public class ReservationViewModel
    {
        public string RoomId { get; set; }

        public virtual Data.Entities.Room Room { get; set; }

        public string ClientId { get; set; }

        public virtual Data.Entities.Client Client { get; set; }

        public virtual Data.Entities.User User { get; set; }

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
