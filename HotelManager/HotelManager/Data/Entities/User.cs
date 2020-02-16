using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManager.Data.Entities;

namespace HotelManager.Data.Entities
{
    public class User
    {
        public User()
        {
            this.ClientReservation = new HashSet<Reservation>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public bool ActiveOrNotActiveAccount { get; set; }

        public DateTime DateOfDismissal { get; set; }

        public bool Admin { get; set; }

        public virtual ICollection<Reservation> ClientReservation { get; set; }
    }
}

