using System.ComponentModel.DataAnnotations;

namespace MobiWeather.Auth.Domain.Contracts.Users
{
    public class LoginContract
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}