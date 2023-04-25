using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mad.Api.Controllers
{
    [ApiController]
    [Route("base")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("get-current")]
        public WeatherForecast GetCurrentWeatherTest()
        {
            var aaa = new WeatherForecast();

            aaa.TemperatureC = 21;

            return aaa;
        }

        [HttpDelete("delete-current/*")]
        public IActionResult DeleteCurrentWeatherTest()
        {
            Console.WriteLine("Unfortonatly deleting");

            return Ok();
        }

        [HttpOptions("options-current")]
        public WeatherForecast OptionOfCurrentWeather()
        {
            var weatherInNewYork = new WeatherForecast();

            weatherInNewYork.Date = new DateOnly(2023, 4, 25);
            weatherInNewYork.TemperatureC = 13;
            weatherInNewYork.Summary = "What I can say about weather in NewYork. Google says it's sunny, but I can't prove it becouse Ihave never been there.";

            return weatherInNewYork;
        }
    }
}