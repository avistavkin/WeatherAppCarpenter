using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;

namespace WeatherApp
{
    class Menu
    {
        static bool willContinue = true;
        static FetchData data = new FetchData();
        public static async Task RunProgram()
        {
            while (willContinue.Equals(true))
            {
                Console.Write("Search For City Press 1:" +
     "\nSearch by lon and lat Press 2:" +
     "\nCollect multiple city data Press 3:" +
     "\nClose Program Press 4:" +
     "\n:> ");

                await MainMenu(Console.ReadLine());
                Console.Clear();
            }
        }

        private static async Task MainMenu(string userInput)
        {
            string url = string.Empty;
            string input = string.Empty;
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter City Name: ");
                    input = Console.ReadLine();
                    Console.Clear();
                    Console.Write(await data.GetAPIData(input));
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Enter lat value: ");
                    input = Console.ReadLine();
                    int lat = int.Parse(input);
                    Console.Write("Enter lon value: ");
                    input = Console.ReadLine();
                    int lon = int.Parse(input);
                    Console.Clear();
                    Console.Write(await data.GetAPIData(lat,lon));
                    Console.ReadKey();
                    break;
                case "3":
                    foreach(var s in await AddCityNames())
                    {
                        Console.WriteLine(await data.GetAPIData(s.CityName)+"\n----------------------------");
                    }
                    Console.ReadKey();
                    break;
                case "4":
                    willContinue = false;
                    break;
                default:
                    break;
            }   
        }

        private static async Task <List<WeatherData>> AddCityNames()
        {
            List<WeatherData> listOfWeatherData = new List<WeatherData>();
            Console.Clear();
            int loop = 0;
            bool continueLoop = true;
            string input = string.Empty;

            while (continueLoop.Equals(true))
            {
                #region
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

                #region 
                if (!input.Equals(string.Empty))
                    {
                        listOfWeatherData.Add(await data.GetAPIData(input));
                    }
                    else if(listOfWeatherData.Count < 1 && input.Equals(string.Empty))
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
