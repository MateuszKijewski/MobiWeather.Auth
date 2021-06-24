using MobiWeather.Auth.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace MobiWeather.Auth.Application.Common.Interfaces.Providers
{
    public interface ITokenProvider
    {
        public JwtSecurityToken GenerateToken(User user);
    }
}