namespace HotelManager.Data.Entities
{
    public class ClientReservation
    {
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}