using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MobiWeather.Auth.Domain.Responses
{
    public class RegisterResponse
    {
        public string Result { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}