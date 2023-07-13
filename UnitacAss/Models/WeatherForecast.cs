using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitacAss.Models
{
    public class WeatherForecast
    {
        public DayWeather Current { get; set; }
        public List<WeekData> Forecast { get; set; }
    }
}
