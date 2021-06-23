using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobiWeather.Auth.Domain.Entities;

namespace MobiWeather.Auth.DataAccess
{
    public class MobiWeatherAuthDbContext : IdentityDbContext
    {
        public MobiWeatherAuthDbContext(DbContextOptions<MobiWeatherAuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}