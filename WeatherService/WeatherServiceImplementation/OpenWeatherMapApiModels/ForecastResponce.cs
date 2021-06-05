using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherServiceImplementation.OpenWeatherMapApiModels
{
    /// <summary>
    /// Weather forecast for 5 days responce
    /// </summary>
    internal class ForecastResponce
    {
        /// <summary>
        /// Forecast list
        /// </summary>
        [JsonPropertyName("list")]
        public List<ListItem> List { get; set; }
    }
}