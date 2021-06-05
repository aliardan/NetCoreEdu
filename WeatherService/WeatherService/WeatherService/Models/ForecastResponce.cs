using System.Collections.Generic;

namespace WeatherService.WeatherService.Models
{
    public class ForecastResponce
    {
        public List<ListItem> list { get; set; }
    }

    public class ListItem
    {
        public string dt_txt { get; set; }
        public Main main { get; set; }
    }
}
