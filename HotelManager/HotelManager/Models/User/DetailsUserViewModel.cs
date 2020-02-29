using System;
using System.Collections.Generic;

namespace HotelManager.Models.User
{
    public class DetailsUserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string FathersName { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public bool ActiveOrNotActiveAccount { get; set; }

        public DateTime DateOfDismissal { get; set; }

        public bool Admin { get; set; }

    }
}
