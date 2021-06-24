using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MobiWeather.Auth.Application.Common.Interfaces.Providers;
using MobiWeather.Auth.Application.Common.Interfaces.Services;
using MobiWeather.Auth.Domain.Contracts.Users;
using MobiWeather.Auth.Domain.Entities;
using MobiWeather.Auth.Domain.Responses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MobiWeather.Auth.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly ITokenProvider _tokenProvider;

        public UserService(UserManager<User> userManager, IConfiguration configuration, ITokenProvider tokenProvider)
        {
            _userManager = userManager;
            _config = configuration;
            _tokenProvider = tokenProvider;
        }

        public async Task<LoginResponse> Login(LoginContract loginContract)
        {
            var user = await _userManager.FindByNameAsync(loginContract.Username);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginContract.Password);

            if (user == null || !isPasswordCorrect)
            {
                throw new InvalidOperationException("Wrong username/password");
            }

            var token = _tokenProvider.GenerateToken(user);

            var response = new LoginResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = token.ValidTo
            };

            return response;
        }

        public async Task<RegisterResponse> Register(RegisterContract registerContract)
        {
            var userExists = await _userManager.FindByNameAsync(registerContract.Username);

            if (userExists != null)
            {
                throw new InvalidOperationException("User already exists!");
            }

            User user = new User()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerContract.Username,
                FirstName = registerContract.FirstName,
                LastName = registerContract.LastName
            };

            var result = await _userManager.CreateAsync(user, registerContract.Password);

            var response = new RegisterResponse()
            {
                Result = result.Succeeded ? "Success" : "Failed",
                Errors = result.Errors.Select(x => x.Description)
            };

            return response;
        }
    }
}