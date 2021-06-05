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

    /// <summary>
    /// List items model
    /// </summary>
    internal class ListItem
    {
        /// <summary>
        /// DateTime
        /// </summary>
        [JsonPropertyName("dt_txt")]
        public string DtTxt { get; set; }

        /// <summary>
        /// Main part of json model
        /// </summary>
        [JsonPropertyName("main")]
        public Main Main { get; set; }
    }
}