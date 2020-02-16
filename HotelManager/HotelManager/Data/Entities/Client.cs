using System;

namespace HotelManager.Data.Entities
{
    public class Client
    {
        public Client()
        {
            this.ClientId = Guid.NewGuid().ToString();
        }

        public string ClientId { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Adult { get; set; }
    }
}
