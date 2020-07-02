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
            FetchData data = new FetchData();
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
                    //preperation for grabbing multple citys
                    Console.WriteLine("not supported, work in progress..");
                    Console.ReadKey();
                    break;
                case "4":
                    willContinue = false;
                    break;
                default:
                    break;
            }
        }
    }
}
