namespace WeatherService.Models
{
    /// <summary>
    /// Weather forecast for 5 days
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// DateTime string
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Metric celsius/fahrenheit
        /// </summary>
        public Metric Metric { get; set; }
    }
}
