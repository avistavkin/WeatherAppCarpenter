using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Data
{
    public class WeatherData
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
        public Wind Wind { get; set; }
        public Main Main { get; set; }
        public Coord Coord { get; set; }
        public string name { get; set; }
    }
}
