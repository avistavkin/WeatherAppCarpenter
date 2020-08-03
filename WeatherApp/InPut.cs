using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Data;

namespace WeatherApp
{
    public class InPut
    {
        private static WeatherData weathers;
        private static FetchData data = new FetchData();

        public static async Task<string> InPutString(int i)
       {
            string apiResponse = string.Empty;

            if (i.Equals(1))
            {
                apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(EnterStringValue("Enter city name: "),i));
            }
            else if (i.Equals(2))
            {
                int lon = int.Parse(EnterStringValue("Enter lat value: "));
                int lat = int.Parse(EnterStringValue("Enter lon value: "));
                Console.Clear();
                apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(lat, lon));
              
            }
            else if (i.Equals(3))
            {
                foreach (var s in await AddCityNames(i))
                {
                    apiResponse += "\n" + OutPut.PrintWeatherCondition(s) + "\n--------------";
                }
            }
            else if (i.Equals(4))
            {
               apiResponse = OutPut.PrintFourDaysForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
            }
            else if (i.Equals(5))
            {
                apiResponse = OutPut.PrintDailyForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
            }
            return apiResponse;
       }

        private static string EnterStringValue(string output)
        {
            Console.Write(output);
            return Console.ReadLine();
        }

        private static async Task<List<WeatherData>> AddCityNames(int value)
        {
            List<WeatherData> listOfWeatherData = new List<WeatherData>();
            Console.Clear();
            bool continueLoop = true;
            string input = string.Empty;

            while (continueLoop.Equals(true))
            {
                #region menu prompts
                if (listOfWeatherData.Count < 1)
                {
                    Console.Write("Type nothing and press enter to exit and continue\nEnter city name: ");
                    input = Console.ReadLine();
                }
                else
                {
                    Console.Write("Enter another city name: ");
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
                    Console.Clear();
                    Console.WriteLine("Input cant be empty");
                    continueLoop = false;
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
