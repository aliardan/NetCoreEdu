using System.Text.Json.Serialization;

namespace WeatherServiceImplementation.OpenWeatherMapApiModels
{
    /// <summary>
    /// Main model
    /// </summary>
    internal class Main
    {
        /// <summary>
        /// Temperature
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}
