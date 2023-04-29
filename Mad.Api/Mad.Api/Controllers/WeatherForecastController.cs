using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("options-current/weather-in-NewYork")]
        public WeatherForecast OptionOfCurrentWeather()
        {
            var weatherInNewYork = new WeatherForecast();

            weatherInNewYork.Date = DateOnly.FromDateTime(DateTime.Now);
            weatherInNewYork.TemperatureC = Random.Shared.Next(-70, 55);
            weatherInNewYork.Summary = Summaries[Random.Shared.Next(Summaries.Length)];

            return weatherInNewYork;
        }
    }
}