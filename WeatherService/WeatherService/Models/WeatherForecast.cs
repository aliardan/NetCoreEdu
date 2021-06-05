﻿using System;

namespace WeatherService.Models
{
    public class WeatherForecast
    {
        public string Date { get; set; }

        public string City { get; set; }

        public double Temperature { get; set; }

        public Metric Metric { get; set; }
    }
}
