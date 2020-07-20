using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Data
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }

        public override string ToString()
        {
            return $"City {name}";
        }
    }
}
