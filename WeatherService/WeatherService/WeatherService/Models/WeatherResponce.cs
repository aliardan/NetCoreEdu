using System.Text.Json.Serialization;

namespace WeatherService.WeatherService.Models
{
    /// <summary>
    /// Weather Responce model
    /// </summary>
    public class WeatherResponce
    {
        /// <summary>
        /// Main part of json model
        /// </summary>
        [JsonPropertyName("main")]
        public Main Main { get; set; }

        /// <summary>
        /// Wind part of json model
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }
}
