﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherServiceImplementation;
using WeatherServiceImplementation.Models;

namespace WeatherService.Controllers
{
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get the city temperature in celsius/fahrenheit
        /// </summary>
        /// <param name="cityName">City name - Moscow</param>
        /// <param name="metric">Metric in celsius/fahrenheit</param>
        [HttpGet("[controller]/temperature/{cityName}/{metric}")]
        public async Task<CityTemperature> GetCityTemperature(string cityName, Metric metric)
        {
            return await _weatherService.GetCityTemperature(cityName, metric);
        }

        /// <summary>
        /// Get the city wind direction and speed
        /// </summary>
        /// <param name="cityName">City name - Moscow</param>
        [HttpGet("[controller]/wind/{cityName}")]
        public async Task<CityWind> GetCityWind(string cityName)
        {
            return await _weatherService.GetCityWind(cityName);
        }

        /// <summary>
        /// Get the city forecast for 5 days
        /// </summary>
        /// <param name="cityName">City name - Moscow</param>
        /// <param name="metric">Metric in celsius/fahrenheit</param>
        [HttpGet("[controller]/{cityName}/future/{metric}")]
        public async Task<List<WeatherForecast>> GetCityForecast(string cityName, Metric metric)
        {
            return  await _weatherService.GetCityForecast(cityName, metric);
        }
    }
}
