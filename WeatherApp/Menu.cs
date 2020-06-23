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
            Console.Write("Search For City Press 1:" +
                "\nClose Program Press 2:" +
                "\n:> ");
            while (willContinue.Equals(true))
            {
                await MainMenu(Console.ReadLine());
                Console.Clear();
            }
        }

        private static async Task MainMenu(string userInput)
        {
            FetchData data = new FetchData();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter City Name: ");
                    string input = Console.ReadLine();
                    await data.GetAPIData(input);
                    Console.ReadKey();
                    break;
                case "2":
                    willContinue = false;
                    break;
                default:
                    break;
            }
        }
    }
}
