using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService.WeatherService _weatherService;

        public WeatherController(WeatherService.WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("[controller]/temperature/{cityName}/{metric}")]
        public async Task<ActionResult<CityTemperature>> GetCityTemperature(string cityName, string metric)
        {
            if (Enum.TryParse(metric, out Metric parsedMetric))
            {
                return await _weatherService.GetCityTemperature(cityName, parsedMetric);
            }

            return new StatusCodeResult(404);
        }

        [HttpGet("[controller]/wind/{cityName}")]
        public async Task<CityWind> GetCityWind(string cityName)
        {
            return await _weatherService.GetCityWind(cityName);
        }

        [HttpGet("[controller]/{cityName}/future/{metric}")]
        public async Task<ActionResult<List<WeatherForecast>>> GetCityForecast(string cityName, string metric)
        {
            if (Enum.TryParse(metric, out Metric parsedMetric))
            {
                return  await _weatherService.GetCityForecast(cityName, parsedMetric);
            }

            return new StatusCodeResult(404);
        }
    }
}
