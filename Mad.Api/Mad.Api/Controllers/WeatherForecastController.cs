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

        [HttpGet("bradamar-week-forecast-console")]
        public IActionResult GetWeekForecast()
        {
            var weatherApp = new WeatherForecast();
            var correctSummary = new CorrectSummaries();

            for (int i = 0; i < 7; i++)
            {
                weatherApp.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));
                weatherApp.TemperatureC = Random.Shared.Next(-30, 40);
                weatherApp.Summary = Summaries[correctSummary.CalculateIndex(weatherApp.TemperatureC)];
                Console.WriteLine("Day - " + weatherApp.Date + " with temperature in Celsius " + weatherApp.TemperatureC + "; in Fahrenheit " + weatherApp.TemperatureF + "; feels " + weatherApp.Summary);
            }

            return Ok();
        }
    }
}