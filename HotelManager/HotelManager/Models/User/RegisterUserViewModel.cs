using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.User
{
    public class RegisterUserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords have to be the same")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FathersName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PersonalNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfAppointment { get; set; }

        // not sure if this is the correct data type for bool data type
        [Required]
        //[DataType(DataType.Custom)]
        public bool ActiveOrNotActiveAccount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfDismissal { get; set; }

        // not sure if this is the correct data type for bool data type
        [Required]
        //[DataType(DataType.Custom)]
        public bool Admin { get; set; }


    }
}
