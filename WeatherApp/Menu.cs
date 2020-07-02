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
                    //List<WeatherData> listOfWeatherData = await AddCityNames();
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


            while (continueLoop.Equals(true))
            {
                if (!loop.Equals(20))
                {
                    if(loop <= 0)
                    {
                        Console.Write("Type nothing and press enter to exit and continue\nEnter city name: ");
                    }
                    else
                    {
                        Console.Write("Enter another city name: ");
                    }
                    string input = Console.ReadLine();
                    if (!input.Equals(string.Empty))
                    {
                        listOfWeatherData.Add(await data.GetAPIData(input));
                        //cityID[loop] = int.Parse(weatherData.id);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        continueLoop = false;
                        //return cityID;
                    }
                }
                else
                {
                    Console.WriteLine($"loop equals {loop}");
                    continueLoop = false;
                }
                loop++;
            }

            return listOfWeatherData; 
        }
    }
}
