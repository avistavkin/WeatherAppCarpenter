using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Data;
namespace WeatherApp
{
    public class OutPut
    {
        public static string PrintWeatherCondition(WeatherData weather)
        {
            string data = $"City: {weather.name}\nTemperature: {weather.main.temp}\nHighest temperature: {weather.main.temp_max}\nLowest temperatur: {weather.main.temp_min}" +
                $"\nFeels like: {weather.main.feels_like}\nHumidity: {weather.main.humidity}\nPressure: {weather.main.pressure}\nWindspeed: {weather.Wind.speed}\nDeg: {weather.Wind.deg}" +
                $"\nCondition: {weather.weather[0].main}\nDescription: {weather.weather[0].description}";
            return data;
        }
        public static void PrintFourDaysForecast(WeatherData weather)
        {
            Console.WriteLine($"4 days weather forecast {weather.city.name}, Coords: {weather.city.coord.lon},{weather.city.coord.lat}");
            foreach(var s in weather.list)
            {
                Console.WriteLine($"------\nDate: {s.dt_txt}\nTemperatur: {s.main.temp}\nHighest temperature: {s.main.temp_max}\nLowest temperatur: {s.main.temp_min}\nFeels like: {s.main.feels_like}\nHumidity: {s.main.humidity}\nPressure: {s.main.pressure}" +
                    $"\nWindspeed: {s.wind.speed}\nDeg: {s.wind.deg}\nCondition: {s.weather[0].main}\nDescription: {s.weather[0].description}");
            }
        }

        public static void PrintDailyForecast()
        {
            //TODO
        }
    }
}
