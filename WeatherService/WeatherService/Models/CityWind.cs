namespace WeatherService.Models
{
    /// <summary>
    /// City Wind Model
    /// </summary>
    public class CityWind
    {
        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// City wind speed
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Wind direction
        /// </summary>
        public Direction Direction { get; set; }
    }
}
