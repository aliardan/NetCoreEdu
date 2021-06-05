namespace WeatherService.Models
{
    /// <summary>
    /// City Temperature Model
    /// </summary>
    public class CityTemperature
    {
        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Metric
        /// </summary>
        public Metric Metric { get; set; }
    }
}
