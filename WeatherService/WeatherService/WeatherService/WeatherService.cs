using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WeatherService.Models;

namespace WeatherService.WeatherService
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherServiceOptions _options;

        public WeatherService(IHttpClientFactory httpClientFactory, IOptions<WeatherServiceOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }
        public async Task<CityTemperature> GetCityTemperature(string cityName, Metric metric)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_options.APIKEY}";
            await client.GetStringAsync(url);
            return null;
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