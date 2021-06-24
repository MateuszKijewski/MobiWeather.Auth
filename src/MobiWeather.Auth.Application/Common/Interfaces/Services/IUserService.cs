using MobiWeather.Auth.Domain.Contracts.Users;
using MobiWeather.Auth.Domain.Responses;
using System.Threading.Tasks;

namespace MobiWeather.Auth.Application.Common.Interfaces.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginContract loginContract);

        Task<RegisterResponse> Register(RegisterContract registerContract);
    }
}