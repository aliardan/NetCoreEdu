using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.WeatherService
{
    public class WeatherService
    {
        public async Task<CityTemperature> GetCityTemperature(string cityName, Metric metric)
        {
            throw new NotImplementedException();
        }

        public async Task<CityWind> GetCityWind(string cityName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WeatherForecast>> GetCityForecast(string cityName, Metric metric)
        {
            throw new NotImplementedException();
        }
    }
}
