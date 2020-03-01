using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.Room
{
    public class RoomInputModel
    {
        public string Id { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public double PricePerAdult { get; set; }

        [Required]
        public double PricePerKid { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
