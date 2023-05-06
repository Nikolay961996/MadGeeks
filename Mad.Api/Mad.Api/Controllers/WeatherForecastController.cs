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

        private readonly int minPossibleTemperature = -40;
        private readonly int maxPossibleTemperature = 40;
        private readonly int daysToPrint = 7;

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

        [HttpGet("bradamar-week-forecast")]
        public IActionResult GetWeekForecast()
        {
            var weatherApp = new WeatherForecast();
            var humanFeelSummaries = new HumanFeelSummaries();
            var forecast = new List<string>();
            var todayDate = DateTime.Today;

            for (int i = 0; i < daysToPrint; i++)
            {
                weatherApp.Date = DateOnly.FromDateTime(todayDate.AddDays(i));
                weatherApp.TemperatureC = Random.Shared.Next(minPossibleTemperature, maxPossibleTemperature);
                weatherApp.Summary = Summaries[humanFeelSummaries.CalculateIndex(weatherApp.TemperatureC)];
                forecast.Add($"Day - {weatherApp.Date} with temperature in Celsius {weatherApp.TemperatureC}; in Fahrenheit {weatherApp.TemperatureF}; feels {weatherApp.Summary}");
            }

            return Ok(forecast);
        }
    }
}