using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace WeatherApp
{
    public class Menu
    {
        private static bool willContinue = true;
        private static FetchData data = new FetchData();
        private const int ExitProgram = 6;

        public static async Task RunProgram()
        {
            while (willContinue.Equals(true))
            {
                try
                {
                     willContinue = await MainMenu(); 
                     Console.Clear();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(ColorAndStyle.SetTextColor(Colors.red, "Input cant be empty!!"));
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(ColorAndStyle.SetTextColor(Colors.red, e.Message));
                }
                finally
                {
                    if (willContinue.Equals(true))
                        Console.ReadKey();
                    
                    Console.Clear();
                }

            }
        }

        private static async Task<bool> MainMenuNavigation(int userInput)
        {
            if (!userInput.Equals(ExitProgram))
            {
                string url = string.Empty;
                string input = string.Empty;
                Console.Clear();
                Console.WriteLine(await InPut.InPutString(userInput));
                Console.ReadKey();
                willContinue = true;
            }
            else
            {
                willContinue = false;
            }
            return willContinue;
        }

        private static async Task<bool> MainMenu()
        {
            OutPut.PrintMainMenu();
            return willContinue = await Menu.MainMenuNavigation(int.Parse(Console.ReadLine()));
        }
    }
}
