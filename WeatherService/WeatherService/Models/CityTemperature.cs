namespace WeatherService.Models
{
    public class CityTemperature
    {
        public string City { get; set; }

        public double Temperature { get; set; }

        public Metric Metric { get; set; }
    }
}
