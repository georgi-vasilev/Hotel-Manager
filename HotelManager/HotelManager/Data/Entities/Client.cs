using System;
using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Adult { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }
    }
}
