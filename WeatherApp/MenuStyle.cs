using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Data;

namespace WeatherApp
{
    public class MenuStyle
    {
        public static string PrintWeatherCondition(WeatherData weather)
        {
            string print = $"City: {weather.name}\nCoords: Lat-{weather.Coord.lat} : Lon-{weather.Coord.lon}\nWindspeed: {weather.Wind.speed}\nDeg: {weather.Wind.deg}\nTemperatur: {weather.Main.temp}\nFeels like: {weather.Main.feels_like}\nHumidity: {weather.Main.humidity}\nPressur: {weather.Main.pressure}\nHighest temperature: {weather.Main.temp_max}\nLowest temperature: {weather.Main.temp_min}";
            return print;
        }
        public static void PrintForeCastCondition(WeatherData weather)
        {
            int days = 1;
           Console.WriteLine($"{weather.list.Count} days weather forecast in {weather.city.name} Lon-{weather.city.coord.lon} : Lat-{weather.city.coord.lat}");
            foreach(var s in weather.list)
            {
                Console.WriteLine($"\n---------\n\nDay {days}\n\nWindspeed: {s.wind.speed}\nDeg: {s.wind.deg}\nTemperature: {s.main.temp}\nFeels like: {s.main.feels_like}\nHumidity: {s.main.humidity}\nPressur: {s.main.pressure}" +
                    $"\nHighest temperatur: {s.main.temp_max}\nLowest temperatur: {s.main.temp_min}");
                days++;
            }
            Console.WriteLine($"\n---------\n");
        }
    }
}
