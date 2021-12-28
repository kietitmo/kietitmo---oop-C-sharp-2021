using System;
using Microsoft.AspNetCore.Mvc;

namespace ReportApp.ReportAppWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("GetWeather")]
        public string Get()
        {
            return "123";
        }

        [HttpPost("sendData")]
        public void SendData([FromBody] WeatherForecast w)
        {
            Console.WriteLine(w.Summary + " " + w.number);
        }
    }
}
