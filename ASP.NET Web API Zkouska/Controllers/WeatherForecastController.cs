using ASP.NET_Web_API_Zkouska;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web_API_Zkouska.Controllers
{


    /*    

         KONTROLERY

        1 kontroler jedna tøída API -> je to table manipulator
        napø. API galerií - 1 kontroler
        API obrázkù - další kontroler

        Action -> get(read)
                  post(create)

    */


    //API - musí být Api Controller
    [ApiController]

    //Routu pojmenovávám jako po celém kontroleru
    // název tohohle API teda bude  -> /_název_konkrétního_kontroleru(tady WeatherForecastController)/(protože je dole HttpGet tak je tam ještì)Get
    //Tudíž na stránce musíme dát adresu /WeatherForecastController/Get


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
        //Tohle vraci zpátky jenom kolekci dat -> Date, Temperature, Summary a vrací to v json struktuøe a vrací jich 5
        //Name vymažeme
        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _db.WeatherForecasts.AsEnumerable();
        }


        [BindProperty(SupportsGet = true)]
        public int Cnt { get; set; }

        //2.Endpoint
        //Tohle vraci zpátky jenom kolekci dat -> Date, Temperature, Summary a vrací to v json struktuøe a vrací jich kolik si nastavim
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














