using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;

namespace WeatherApp
{
    class Menu
    {
        static string url = "http://api.openweathermap.org/data/2.5/weather?q=";
        static bool willContinue = true;
        public static async Task RunProgram()
        {
            Console.Write("Search For City Press 1:" +
                "\nSearch by lon and lat" +
                "\nClose Program Press 3:" +
                "\n:> ");
            while (willContinue.Equals(true))
            {
                await MainMenu(Console.ReadLine());
                Console.Clear();
            }
        }

        private static async Task MainMenu(string userInput)
        {
            string input = string.Empty;
            FetchData data = new FetchData();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter City Name: ");
                    input = Console.ReadLine();
                    Console.Write(await data.GetAPIData(input,url));
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Enter lon value: ");
                    input = Console.ReadLine();
                    int lon = int.Parse(input);
                    Console.Write("Enter lat value: ");
                    input = Console.ReadLine();
                    int lat = int.Parse(input);
                    //Console.Write(await data.GetAPIData().ToString());
                    //Console.ReadKey();
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
