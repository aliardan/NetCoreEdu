using System.Collections.Generic;

namespace WeatherService.WeatherService.Models
{
    /// <summary>
    /// Weather forecast for 5 days responce
    /// </summary>
    public class ForecastResponce
    {
        public List<ListItem> list { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// DateTime
        /// </summary>
        public string dt_txt { get; set; }
        public Main main { get; set; }
    }
}
