using System.Text.Json.Serialization;

namespace WeatherService.WeatherService.Models
{
    /// <summary>
    /// Main model
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Temperature
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}
