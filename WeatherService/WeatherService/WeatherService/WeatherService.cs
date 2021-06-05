using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherService.Models;
using WeatherService.WeatherService.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            var stringRes = await client.GetStringAsync(url);
            var res = JsonSerializer.Deserialize<WeatherResponce>(stringRes);

            var temp = metric == Metric.Celsius 
                ? ConvertKelvinToCelsius(res.main.temp) 
                : ConvertKelvinToFarenheit(res.main.temp);

            var result = new CityTemperature
            {
                City = cityName,
                Metric = metric,
                Temperature = temp
            };

            return result;
        }

        public async Task<CityWind> GetCityWind(string cityName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WeatherForecast>> GetCityForecast(string cityName, Metric metric)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");

            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={_options.APIKEY}";
            var stringRes = await client.GetStringAsync(url);
            var res = JsonSerializer.Deserialize<ForecastResponce>(stringRes);

            var result = res.list.Select(x => new WeatherForecast()
            {
                City = cityName,
                Date = DateTime.Parse(x.dt_txt),
                Metric = metric,
                Temperature = metric == Metric.Celsius
                    ? ConvertKelvinToCelsius(x.main.temp)
                    : ConvertKelvinToFarenheit(x.main.temp)
            });

            return result.ToList();
        }

        private double ConvertKelvinToCelsius(double temperature)
        {
            return temperature - 273;
        }

        private double ConvertKelvinToFarenheit(double temperature)
        {
            throw new NotImplementedException();
        }
    }
}