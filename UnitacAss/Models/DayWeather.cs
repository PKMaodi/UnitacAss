using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitacAss.Models
{
    public class DayWeather
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public int WindSpeed { get; set; }
        public int WindDeg
        { get; set; }
    }
}
