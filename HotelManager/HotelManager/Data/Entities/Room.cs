using System;
using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class Room
    {
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RoomReservations = new HashSet<Reservation>();
        }

        public string Id { get; set; }

        public int Capacity { get; set; }

        public string RoomType { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerKid { get; set; }

        public int RoomNumber { get; set; }

        public virtual ICollection<Reservation> RoomReservations { get; set; }
    }
}
