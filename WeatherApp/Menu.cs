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
        public static async Task RunProgram()
        {
            while (willContinue.Equals(true))
            {
                Console.Write("Search For City Press 1:" +
     "\nSearch by lon and lat Press 2:" +
     "\nClose Program Press 3:" +
     "\n:> ");

                await MainMenu(Console.ReadLine());
                Console.Clear();
            }
        }

        private static async Task MainMenu(string userInput)
        {
            string url = string.Empty;
            string input = string.Empty;
            FetchData data = new FetchData();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    url = "http://api.openweathermap.org/data/2.5/weather?q=";
                    Console.Write("Enter City Name: ");
                    input = Console.ReadLine();
                    Console.Clear();
                    Console.Write(await data.GetAPIData(input));
                    Console.ReadKey();
                    break;
                case "2":
                    url = "https://api.openweathermap.org/data/2.5/onecall?";
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
                    willContinue = false;
                    break;
                default:
                    break;
            }
        }
    }
}
