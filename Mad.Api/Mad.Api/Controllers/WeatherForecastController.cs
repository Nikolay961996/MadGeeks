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

        [HttpPost("post-current")]

        public string NotificationToCivilians()
        {
            var NowWeather = new WeatherForecast();
            NowWeather.TemperatureC = Random.Shared.Next(-45, 55);
            string alert = $"Everything is nice! Enjoy your life! The Temperature is {NowWeather.TemperatureC}";
            if (NowWeather.TemperatureC > 25 || NowWeather.TemperatureC < -5)
            {
                alert = $"The weater is shitty, bro! Stay home! The Temperature is {NowWeather.TemperatureC}";
            }
            return alert;
        }


    }
}