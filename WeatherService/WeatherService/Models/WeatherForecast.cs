using System;

namespace WeatherService.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public string City { get; set; }

        public int Temperature { get; set; }

        public Metric Metric { get; set; }
    }
}
