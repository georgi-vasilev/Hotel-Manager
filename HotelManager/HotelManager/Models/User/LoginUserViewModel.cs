using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.User
{
    public class LoginUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
