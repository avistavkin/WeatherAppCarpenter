using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WeatherApp.Data;
namespace WeatherApp
{
    public class OutPut
    {
        public static string PrintMenuOptions(int index)
        {
            string [] menuText = {"Search For City Press 1:", "Search by lon and lat Press 2:", "Collect multiple city data Press 3:", 
                "Four Days Weather Forecast Press 4:", "Daily Weather Forecast 5:" ,"Close Program Press 6:", ":> " };

            ColorAndStyle.SetTextColor(Colors.Magenta);
            ColorAndStyle.SetTextPosition(menuText[index],35,8+index);
            return menuText[index];
        }

        public static string PrintWeatherCondition(WeatherData weather)
        {
            string data = string.Empty;
            if (!weather.Equals(null))
            {
                data = $"City: {weather.name}\nTemperature: {weather.main.temp}\nHighest temperature: {weather.main.temp_max}\nLowest temperatur: {weather.main.temp_min}" +
                            $"\nFeels like: {weather.main.feels_like}\nHumidity: {weather.main.humidity}\nPressure: {weather.main.pressure}\nWindspeed: {weather.Wind.speed}\nDeg: {weather.Wind.deg}" +
                             $"\nCondition: {weather.weather[0].main}\nDescription: {weather.weather[0].description}";
            }
            else
            {
                throw new Exception("PrintWeatherCondition cant be empty");
            }

            return data;
        }
        public static string PrintFourDaysForecast(WeatherData weather)
        {
            string data = string.Empty;
            data = $"4 days weather forecast {weather.city.name}, Coords: {weather.city.coord.lon},{weather.city.coord.lat}" + "\n";
            foreach (var s in weather.list)
            {
                data += $"\n------\nDate: {s.dt_txt}\nTemperatur: {s.main.temp}\nHighest temperature: {s.main.temp_max}\nLowest temperatur: {s.main.temp_min}\nFeels like: {s.main.feels_like}\nHumidity: {s.main.humidity}\nPressure: {s.main.pressure}" +
                    $"\nWindspeed: {s.wind.speed}\nDeg: {s.wind.deg}\nCondition: {s.weather[0].main}\nDescription: {s.weather[0].description}";
            }
            return data;
        }

        public static string PrintDailyForecast(WeatherData weather)
        {
            string data = string.Empty;
            string dateNow = DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "-");
            data = $"Daily weather forecast {weather.city.name}, Coords: {weather.city.coord.lon},{weather.city.coord.lat}";
            foreach (var s in weather.list)
            {
                string Apidate = s.dt_txt.Remove(10).ToString();//removes time from the string

                if (Apidate.Equals(dateNow))
                {
                    data += $"\n------\nDate: {s.dt_txt}\nTemperatur: {s.main.temp}\nHighest temperature: {s.main.temp_max}\nLowest temperatur: {s.main.temp_min}\nFeels like: {s.main.feels_like}\nHumidity: {s.main.humidity}\nPressure: {s.main.pressure}" +
                      $"\nWindspeed: {s.wind.speed}\nDeg: {s.wind.deg}\nCondition: {s.weather[0].main}\nDescription: {s.weather[0].description}";
                }
            }
            return data;
        }
    }
}
