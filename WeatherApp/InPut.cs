using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;

namespace WeatherApp
{
    public class InPut
    {
        private static WeatherData weathers;
        private static FetchData data = new FetchData();
        private const int _SearchForOneCity = 1;
        private const int _SearchBylongLat = 2;
        private const int _SearchForMultipleCities = 3;
        private const int _FourDaysForeCast = 4;
        private const int _DailyForCast = 5;
        private const int menuX = 44;
        private const int menuY = 10;
        private static List<string>  apiResponse = new List<string>();

        public static async Task<List<string>> InPutString(int i)
        {
            string input = string.Empty;

            if (i.Equals(_SearchForOneCity))
            {
                OutPut.PrintMenuFrame();
                ColorAndStyle.SetTextColor(Colors.Magenta);
                input = EnterStringValue(ColorAndStyle.SetTextPosition("Enter city name: ",menuX,menuY));
                if (input.Equals(string.Empty))
                    return null;

                apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(input, i)).ToList();
            }
            else if (i.Equals(_SearchBylongLat))
            {
                OutPut.PrintMenuFrame();
                ColorAndStyle.SetTextColor(Colors.Magenta);
                int lon = int.Parse(EnterStringValue(ColorAndStyle.SetTextPosition("Enter lat value: ", menuX, menuY)));
                int lat = int.Parse(EnterStringValue(ColorAndStyle.SetTextPosition("Enter lon value: ", menuX, menuY)));
                Console.Clear();
                apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(lat, lon)).ToList();
            }
            else if (i.Equals(_SearchForMultipleCities))
            {
                OutPut.PrintMenuFrame();
                ColorAndStyle.SetTextColor(Colors.Magenta);
                foreach (var s in await AddCityNames(i))
                {
                     apiResponse = OutPut.PrintWeatherCondition(s).ToList();
                }
            }
            else if (i.Equals(_FourDaysForeCast))
            {
                OutPut.PrintMenuFrame();
                ColorAndStyle.SetTextColor(Colors.Magenta);
                apiResponse = OutPut.PrintFourDaysForecast(await data.GetAPIResponse(EnterStringValue(ColorAndStyle.SetTextPosition("Enter city name: ", menuX, menuY)), i));
            }
            else if (i.Equals(_DailyForCast))
            {
                OutPut.PrintMenuFrame();
                ColorAndStyle.SetTextColor(Colors.Magenta);
                apiResponse = OutPut.PrintDailyForecast(await data.GetAPIResponse(EnterStringValue(ColorAndStyle.SetTextPosition("Enter city name: ", menuX, menuY)), i)).ToList();
            }

            return apiResponse;
        }

        private static string EnterStringValue(string output)
        {
            Console.Write(output);
            string value = string.Empty;
            value = Console.ReadLine();
            return value;
        }

        private static async Task<List<WeatherData>> AddCityNames(int value)
        {
            List<WeatherData> listOfWeatherData = new List<WeatherData>();
            bool continueLoop = true;
            string input = string.Empty;

            while (continueLoop.Equals(true))
            {
                #region menu prompts
                if (listOfWeatherData.Count < 1)
                {
                    ColorAndStyle.SetTextColor(Colors.red);
                    Console.Write(ColorAndStyle.SetTextPosition("Press enter to exit or enter city", menuX-8, menuY));
                    ColorAndStyle.SetTextColor(Colors.Magenta);
                    Console.WriteLine(ColorAndStyle.SetTextPosition("Enter city  name:",menuX-8,menuY+1));
                    ColorAndStyle.SetTextPosition(string.Empty,menuX+10,menuY+1);
                    input = Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    OutPut.PrintMenuFrame();
                    ColorAndStyle.SetTextColor(Colors.red);
                    Console.Write(ColorAndStyle.SetTextPosition("Press enter to exit or enter city", menuX-8, menuY));
                    ColorAndStyle.SetTextColor(Colors.Magenta);
                    Console.WriteLine(ColorAndStyle.SetTextPosition("Enter another city: ", menuX-8, menuY + 1));
                    ColorAndStyle.SetTextPosition(string.Empty, menuX + 11, menuY + 1);
                    input = Console.ReadLine();
                }
                #endregion

                #region handle user input
                if (!input.Equals(string.Empty))
                {
                    weathers = await data.GetAPIResponse(input, 1);
                    listOfWeatherData.Add(weathers);
                }
                else if (listOfWeatherData.Count < 1 && input.Equals(string.Empty))
                {
                    throw new Exception("first input cant be empty!!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------");
                    continueLoop = false;
                }
                #endregion
            }

            return listOfWeatherData;
        }


    }
}
