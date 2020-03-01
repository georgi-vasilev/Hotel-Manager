using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.User
{
    public class LoginUserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
