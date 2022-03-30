using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web_API_Zkouska
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
