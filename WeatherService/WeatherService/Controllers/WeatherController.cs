using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    /// <inheritdoc />
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService.WeatherService _weatherService;

        /// <inheritdoc />
        public WeatherController(WeatherService.WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get the city temperature in celcius/fahrenheit
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="metric">Metric in celcius/fahrenheit</param>
        /// <returns></returns>
        [HttpGet("[controller]/temperature/{cityName}/{metric}")]
        public async Task<ActionResult<CityTemperature>> GetCityTemperature(string cityName, string metric)
        {
            if (Enum.TryParse(metric, out Metric parsedMetric))
            {
                return await _weatherService.GetCityTemperature(cityName, parsedMetric);
            }

            return new StatusCodeResult(404);
        }

        /// <summary>
        /// Get the city wind direction and speed
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns></returns>
        [HttpGet("[controller]/wind/{cityName}")]
        public async Task<CityWind> GetCityWind(string cityName)
        {
            return await _weatherService.GetCityWind(cityName);
        }

        /// <summary>
        /// Get the city forecast for 5 days
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="metric">Metric in celcius/fahrenheit</param>
        /// <returns></returns>
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
