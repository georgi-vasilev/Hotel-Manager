using HotelManager.Data.Entities;
using System.Collections.Generic;

namespace HotelManager.Models.Client
{
    public class ClientViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Adult { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }
        public ClientViewModel()
        {
            this.Id = System.Guid.NewGuid().ToString();
        }
    }
}
