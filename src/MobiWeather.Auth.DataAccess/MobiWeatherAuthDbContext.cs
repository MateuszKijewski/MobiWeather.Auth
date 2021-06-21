using Microsoft.EntityFrameworkCore;
using MobiWeather.Auth.Domain.Entities;

namespace MobiWeather.Auth.DataAccess
{
    public class MobiWeatherAuthDbContext : DbContext
    {
        public MobiWeatherAuthDbContext(DbContextOptions<MobiWeatherAuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}