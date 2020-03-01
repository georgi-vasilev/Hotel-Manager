using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.Reservation
{
    public class ReservationInputModel
    {
        public ReservationInputModel()
        {
            Clients = new List<ClientInputModel>()
            {
                new ClientInputModel()
            };
        }

        public string RoomId { get; set; }

        public string UserId { get; set; }

        public string Id { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Bills { get; set; }

        public List<ClientInputModel> Clients { get; set; }
    }
}
