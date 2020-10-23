using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RPS_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("~/WeatherForecast/GonnaPostAName")]
        [Route("~/WeatherForecast/GonnaPostAName/{name}")]
        [Route("~/WeatherForecast/GonnaPostAName/{name}/{age}")]
        [HttpPost("name")]
        public ActionResult<string> PostAName(string name, int age)
        {
            string newName = "";
            if (age <= 0)
            {
                newName = "Welcome " + name;
            }
            else
            {
                newName = "Welcome " + name + " you are " + age + " years old.";
            }
            return newName;
        }

        [Route("~/WeatherForecast/PostAName")]
        [HttpGet]
        public ActionResult<string> PostAName()
        {
            return "Kevin";
        }
    }
}
