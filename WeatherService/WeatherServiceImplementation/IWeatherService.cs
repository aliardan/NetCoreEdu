using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherServiceImplementation.Models;

namespace WeatherServiceImplementation
{
    public interface IWeatherService
    {
        /// <summary>
        /// Get the city temperature
        /// </summary>
        /// <param name="cityName">City name</param>
        public Task<CityTemperature> GetCityTemperature(string cityName, Metric metric);

        /// <summary>
        /// Get the city wind direction and speed
        /// </summary>
        /// <param name="cityName">City name</param>
        public Task<CityWind> GetCityWind(string cityName);

        /// <summary>
        /// Get the city forecast for 5 days
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="metric">Metric in celsius/fahrenheit</param>
        public Task<List<WeatherForecast>> GetCityForecast(string cityName, Metric metric);
    }
}
