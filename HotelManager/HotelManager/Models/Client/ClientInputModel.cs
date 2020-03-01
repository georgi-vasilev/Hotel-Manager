using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.Client
{
    public class ClientInputModel
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public bool Adult { get; set; }
    }
}
