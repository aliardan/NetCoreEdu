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
        [HttpGet("[controller]/temperature/{cityName}/{Metric}")]
        public async Task<ActionResult<CityTemperature>> GetCityTemperature(string cityName, string metric)
        {
            Metric parsedMetric;

            if (Metric.TryParse(metric, out parsedMetric))
            {
                throw new NotImplementedException();
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        [HttpGet("[controller]/wind/{cityName}")]
        public async Task<CityWind> GetCityWind(string cityName)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[controller]/{cityName}/future/{Metric}")]
        public async Task<ActionResult<List<WeatherForecast>>> GetCityForecast(string cityName, string metric)
        {
            Metric parsedMetric;

            if (Metric.TryParse(metric, out parsedMetric))
            {
                throw new NotImplementedException();
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
    }
}
