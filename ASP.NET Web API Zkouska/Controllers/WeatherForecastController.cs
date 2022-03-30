using ASP.NET_Web_API_Zkouska;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web_API_Zkouska.Controllers
{


    /*    

         KONTROLERY

        1 kontroler jedna t��da API -> je to table manipulator
        nap�. API galeri� - 1 kontroler
        API obr�zk� - dal�� kontroler

        Action -> get(read)
                  post(create)

    */


    //API - mus� b�t Api Controller
    [ApiController]

    //Routu pojmenov�v�m jako po cel�m kontroleru
    // n�zev tohohle API teda bude  -> /_n�zev_konkr�tn�ho_kontroleru(tady WeatherForecastController)/(proto�e je dole HttpGet tak je tam je�t�)Get
    //Tud� na str�nce mus�me d�t adresu /WeatherForecastController/Get


    //CONTROLER
    //api/[controller]

    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //ENDPOINT
        //Tohle vraci zp�tky jenom kolekci dat -> Date, Temperature, Summary a vrac� to v json struktu�e a vrac� jich 5
        //Name vyma�eme
        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _db.WeatherForecasts.AsEnumerable();
        }


        [BindProperty(SupportsGet = true)]
        public int Cnt { get; set; }

        //2.Endpoint
        //Tohle vraci zp�tky jenom kolekci dat -> Date, Temperature, Summary a vrac� to v json struktu�e a vrac� jich kolik si nastavim
        [HttpGet("Get/{cnt}")]
        public IEnumerable<WeatherForecast> GetCnt()
        {
            return Enumerable.Range(1, Cnt).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [BindProperty]
        public WeatherForecastIM NewForecast { get; set; }

        [HttpPost]

        public WeatherForecast CreateNew()
        {
            WeatherForecast data = new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = NewForecast.TemperatureC,
                Summary = NewForecast.Summary
            };
            
            _db.WeatherForecasts.Add(data);
            _db.SaveChanges();
            return data;
        }

    }
}




// 30.3. 2.hodina API



//OLTP --update intensive - (insert, update, delete)

//OLAP -- data mining - (select)














