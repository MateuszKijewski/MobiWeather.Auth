using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobiWeather.Auth.Application.Common.Interfaces.Providers;
using MobiWeather.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobiWeather.Auth.Application.Providers
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _config;
        public TokenProvider(IConfiguration configuration)
        {
            _config = configuration;
        }

        public JwtSecurityToken GenerateToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}