using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiWeather.Auth.Domain.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
