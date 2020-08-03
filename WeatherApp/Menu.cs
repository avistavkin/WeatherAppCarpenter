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
        private static bool willContinue = true;
        private static FetchData data = new FetchData();
    

        public static async Task RunProgram()
        {
            while (willContinue.Equals(true))
            {
                Console.Write(OutPut.PrintMenuOptions());
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
                    Console.WriteLine(await InPut.InPutString(int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine(await InPut.InPutString(int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine(await InPut.InPutString(int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine(await InPut.InPutString(int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine(await InPut.InPutString(int.Parse(userInput)));
                    Console.ReadKey();
                    break;
                case "6":
                    willContinue = false;
                    break;
                default:
                    break;
            }   
        }   
    }
}
