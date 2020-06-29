using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class HandleDataFormat
    {
        public static WeatherData ConvertJson(JObject data)
        {
            WeatherData weather = new WeatherData();
            weather.weather = JsonConvert.DeserializeObject<List<Weather>>(data["weather"].ToString());

            weather.CountryName = data["name"].ToString();
            weather.temp = data["main"]["temp"].ToString();
            weather.pressure = data["main"]["pressure"].ToString();
            weather.humidity = data["main"]["humidity"].ToString();
            weather.windSpeed = data["wind"]["speed"].ToString();
            weather.deg = data["wind"]["deg"].ToString();
            weather.lat = data["coord"]["lat"].ToString();
            weather.lon = data["coord"]["lon"].ToString();

            return weather;
        }
    }
}
