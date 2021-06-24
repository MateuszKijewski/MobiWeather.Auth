using Microsoft.AspNetCore.Mvc;
using MobiWeather.Auth.Application.Common.Interfaces.Services;
using MobiWeather.Auth.Domain.Contracts.Users;
using MobiWeather.Auth.WebApi.Helpers;
using System;
using System.Threading.Tasks;

namespace MobiWeather.Auth.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] LoginContract loginContract)
        {
            try
            {
                var response = await _userService.Login(loginContract);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.User.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterContract registerContract)
        {
            try
            {
                var response = await _userService.Register(registerContract);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
