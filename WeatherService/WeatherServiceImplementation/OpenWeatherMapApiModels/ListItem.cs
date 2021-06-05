using System.Text.Json.Serialization;

namespace WeatherServiceImplementation.OpenWeatherMapApiModels
{
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