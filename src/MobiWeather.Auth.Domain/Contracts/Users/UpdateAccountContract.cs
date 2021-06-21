using System;

namespace MobiWeather.Auth.Domain.Contracts.Users
{
    public class UpdateAccountContract
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
