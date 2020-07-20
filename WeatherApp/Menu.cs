using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using System.Linq;

namespace WeatherApp
{
    class Menu
    {
        static bool willContinue = true;
        static FetchData data = new FetchData();
        private static WeatherData weathers;
        public static async Task RunProgram()
        {
            while (willContinue.Equals(true))
            {
                Console.Write("Search For City Press 1:" +
     "\nSearch by lon and lat Press 2:" +
     "\nCollect multiple city data Press 3:" +
     "\n(Broken) Weather Forcast Press 4:" +
     "\nClose Program Press 5:" +
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
                    weathers = await data.GetAPIData(input, int.Parse(userInput));
                    Console.Write(weathers.name);

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
                    weathers = await data.GetAPIData(lat,lon);
                        Console.Write(weathers.name);
                    Console.ReadKey();
                    break;
                case "3":
                    foreach(var s in await AddCityNames(int.Parse(userInput)))
                    {
                        Console.WriteLine(s + "\n----------------------------");
                    }
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Write("Enter City Name: ");
                    input = Console.ReadLine();
                    Console.Clear();
                    Console.Write(await data.GetAPIData(input, int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "5":
                    willContinue = false;
                    break;
                default:
                    break;
            }   
        }

        private static async Task <List<WeatherData>> AddCityNames(int value)
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
                    weathers = await data.GetAPIData(input, 1);
                    listOfWeatherData.Add(weathers);
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
