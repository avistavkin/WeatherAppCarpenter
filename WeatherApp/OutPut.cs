using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Data;
namespace WeatherApp
{
    public class OutPut
    {
        private const int menuY = 8;
        private const int menuX = 36;
        private const int MenuSize = 7;

        private static string PrintMenuOptions(int index,int x,int y)
        {
            string [] menuText = {"Search For City Press 1:", "Search by lon and lat Press 2:", "Collect multiple city data Press 3:", 
                "Four Days Weather Forecast Press 4:", "Daily Weather Forecast 5:" ,"Close Program Press 6:", ":> "};
            
            ColorAndStyle.SetTextColor(Colors.Magenta);
            return ColorAndStyle.SetTextPosition(menuText[index], x, y + index);
        }

        public static string PrintErrorMessages(string message,int userX,int userY)
        {
            Console.Clear();
            Threads.StartThreadWithJoin(new Thread(new ThreadStart(OutPut.PrintMenuFrame)));
            ColorAndStyle.SetTextColor(Colors.red, string.Empty);
            return ColorAndStyle.SetTextPosition(message, menuX+userX, menuY+userY);
        }


        public static void PrintMenuFrame()//TODO work in progress, just temporary. Want to avoid void
        {
            
            ColorAndStyle.SetTextColor(Colors.white);
            Console.WriteLine(ColorAndStyle.SetTextPosition("***********************************", menuX, menuY - 5));
            ColorAndStyle.SetTextColor(Colors.green);
            Console.WriteLine(ColorAndStyle.SetTextPosition("WeatherApp", menuX + 12, menuY - 4));
            ColorAndStyle.SetTextColor(Colors.white);

            for (int i = 0; i < MenuSize - 5; i++)
            {
                Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX, menuY + i - 4));
                Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX + 34, menuY + i - 4));
            }


            Console.WriteLine(ColorAndStyle.SetTextPosition("**************************************************", menuX - 8, menuY - 2));
            Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX + 41, menuY - 1));
            Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX + -8, menuY - 1));

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX - 8, menuY + i));
                Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX + 41, menuY + i));
            }


            Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX - 8, menuY + MenuSize));
            Console.WriteLine(ColorAndStyle.SetTextPosition("*", menuX +41, menuY + MenuSize));
            Console.WriteLine(ColorAndStyle.SetTextPosition("**************************************************", menuX - 8, menuY + 13 + 1));
        }

        public static void PrintMainMenu()//TODO work in progress, just temporary. Want to avoid void
        {
            for (int i = 0; i < MenuSize; i++)
            {
                Console.Write(OutPut.PrintMenuOptions(i, menuX, menuY+3));
            }
            ColorAndStyle.SetTextPosition("", menuX + 3, menuY + MenuSize+2);//resets the cursour at >: in the menu
        }

        public static string[] PrintWeatherCondition(WeatherData weather)
        {
            string[] data;
            if (!weather.Equals(null))
            {
                data = new string []{"City: " + weather.name, "Temperature: "+weather.main.temp, "Highest temperature: " +weather.main.temp_max,"Lowest temperatur: "+ weather.main.temp_min,
                "Feels like: " + weather.main.feels_like,"Humidity: "+ weather.main.humidity,"Pressure: "+ weather.main.pressure,"Windspeed: "+weather.Wind.speed,"Deg: "+ weather.Wind.deg,
                "Condition: "+ weather.weather[0].main,"Description: " +weather.weather[0].description};
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
