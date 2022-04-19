using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController] //types are used to serve HTTP API responses
    [Route("[controller]")] //the Route will be the name of controller before "Controller" name: (here WeatherForecast, not WeatherForecastController)
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        //constructor
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger; //_logger - private field 
        }

        
        [HttpGet(Name = "GetWeatherForecast")] //get method, name = "..." necessary for Swagger
        //[HttpGet("weather")] //route name "WeatherForecast/weather" with http method get
        //[Route("weather") //only route name
        public IEnumerable<WeatherForecast> Get()
        {
            //logic of get method
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}