using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Models;
using WeatherService.WeatherService.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherService.WeatherService
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherServiceOptions _options;

        /// <summary>
        /// Weather Service
        /// </summary>
        /// <param name="httpClientFactory">Client</param>
        /// <param name="options">APIKey</param>
        public WeatherService(IHttpClientFactory httpClientFactory, IOptions<WeatherServiceOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        /// <summary>
        /// Get the city temperature
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="metric">Metric in celsius/fahrenheit</param>
        public async Task<CityTemperature> GetCityTemperature(string cityName, Metric metric)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_options.APIKEY}";
            var stringRes = await client.GetStringAsync(url);
            var res = JsonSerializer.Deserialize<WeatherResponce>(stringRes);

            var temp = metric == Metric.celsius 
                ? ConvertKelvinToCelsius(res.Main.Temp) 
                : ConvertKelvinToFarenheit(res.Main.Temp);

            var result = new CityTemperature
            {
                City = cityName,
                Metric = metric,
                Temperature = temp
            };

            return result;
        }

        /// <summary>
        /// Get the city wind direction and speed
        /// </summary>
        /// <param name="cityName">City name</param>
        public async Task<CityWind> GetCityWind(string cityName)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_options.APIKEY}";
            var stringRes = await client.GetStringAsync(url);
            var res = JsonSerializer.Deserialize<WeatherResponce>(stringRes);
            
            var result = new CityWind()
            {
                City = cityName,
                Speed = res.Wind.Speed,
                Direction = ToDirection(res.Wind.Degree)
            };

            return result;
        }

        /// <summary>
        /// Get the city forecast for 5 days
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="metric">Metric in celsius/fahrenheit</param>
        public async Task<List<WeatherForecast>> GetCityForecast(string cityName, Metric metric)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");

            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={_options.APIKEY}";
            var stringRes = await client.GetStringAsync(url);
            var res = JsonSerializer.Deserialize<ForecastResponce>(stringRes);

            var result = res.List.Select(x => new WeatherForecast()
            {
                City = cityName,
                Date = DateTime.ParseExact(x.DtTxt, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd"),
                Metric = metric,
                Temperature = metric == Metric.celsius
                    ? ConvertKelvinToCelsius(x.Main.Temp)
                    : ConvertKelvinToFarenheit(x.Main.Temp)
            });

            return result.Where((value, index) => index % 8 == 0).ToList();
        }

        private double ConvertKelvinToCelsius(double temperature)
        {
            return Math.Round(temperature - 273.15, 2);
        }

        private double ConvertKelvinToFarenheit(double temperature)
        {
            return Math.Round((temperature - 273.15) * 9 / 5 + 32, 2);
        }

        private Direction ToDirection(double degree)
        {
            return degree switch
            {
                > 337.5 => Direction.North,
                > 292.5 => Direction.Northwest,
                > 247.5 => Direction.West, 
                > 202.5 => Direction.Southwest,
                > 157.5 => Direction.South,
                > 122.5 => Direction.Southeast,
                > 67.5 => Direction.East,
                > 22.5 => Direction.Northeast,
                _ => Direction.North
            };
        }
    }
}