using System.Text.Json.Serialization;

namespace WeatherService.WeatherService.Models
{
    /// <summary>
    /// Wind model
    /// </summary>
    public class Wind
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
