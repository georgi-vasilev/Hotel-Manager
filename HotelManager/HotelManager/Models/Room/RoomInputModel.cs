namespace HotelManager.Models.Room
{
    public class RoomInputModel
    {
        public int Capacity { get; set; }

        public string RoomType { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerKid { get; set; }

        public int RoomNumber { get; set; }
    }
}
