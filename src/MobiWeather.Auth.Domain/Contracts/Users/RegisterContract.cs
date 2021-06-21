using System.ComponentModel.DataAnnotations;

namespace MobiWeather.Auth.Domain.Contracts.Users
{
    public class RegisterContract
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}