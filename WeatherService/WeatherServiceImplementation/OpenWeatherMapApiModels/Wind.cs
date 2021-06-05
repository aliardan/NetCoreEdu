using System.Text.Json.Serialization;

namespace WeatherServiceImplementation.OpenWeatherMapApiModels
{
    /// <summary>
    /// Wind model
    /// </summary>
    internal class Wind
    {
        /// <summary>
        /// Wind speed
        /// </summary>
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        /// Wind degree direction
        /// </summary>
        [JsonPropertyName("deg")]
        public double Degree { get; set; }
    }
}
