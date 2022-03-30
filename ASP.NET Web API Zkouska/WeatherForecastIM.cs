using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Web_API_Zkouska
{




    // Jenom model -> bude obsahovat Date, TemperatureC, TemperatureF a Summary
    public class WeatherForecastIM
    {
       
        [Required]
        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}