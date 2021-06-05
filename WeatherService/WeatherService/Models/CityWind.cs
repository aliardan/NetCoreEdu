namespace WeatherService.Models
{
    public class CityWind
    {
        public string City { get; set; }
        
        public double Speed { get; set; }

        public Direction Direction { get; set; }
    }
}
