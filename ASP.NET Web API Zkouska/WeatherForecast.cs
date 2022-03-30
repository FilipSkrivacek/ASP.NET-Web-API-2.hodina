using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Web_API_Zkouska
{




    // Jenom model -> bude obsahovat Date, TemperatureC, TemperatureF a Summary
    public class WeatherForecast
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}