using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitacAss.Service
{
    class CurrentWeather
    {
        public string weather;
        public PretoriaWeather pretoriaWeather;

        public class PretoriaWeather
        {
            public string condition;
            public double min_temp;
            public double max_temp;
        }
    }
}