﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HotelManager.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.ClientReservation = new HashSet<Reservation>();
        }

        public string FirstName { get; set; }

        public string FathersName { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public bool ActiveOrNotActiveAccount { get; set; }

        public DateTime DateOfDismissal { get; set; }

        public bool Admin { get; set; }

        public virtual ICollection<Reservation> ClientReservation { get; set; }
    }
}

