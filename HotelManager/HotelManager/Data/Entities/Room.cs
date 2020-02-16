using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public int Capacity { get; set; }

        public List<string> RoomType { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerKid { get; set; }

        public int RoomNumber { get; set; }
    }
}
