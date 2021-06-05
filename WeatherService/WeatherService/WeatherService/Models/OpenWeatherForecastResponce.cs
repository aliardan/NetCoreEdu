using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.WeatherService.Models
{
    public class OpenWeatherForecastResponce
    {
        public Main main { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
    }
}
