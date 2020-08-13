using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Threading;

namespace WeatherApp
{
    public class Menu
    {
        private static bool willContinue = true;
        private static FetchData data = new FetchData();
        private const int ExitProgram = 6;

        public static void Main()
        {
            Threads.StartThread(new Thread(RunProgram)).Name = "first thread";
        }

        private static void RunProgram()
        {

            while (willContinue.Equals(true))
            {
                try
                {
                    willContinue = MainMenu();
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine(OutPut.PrintErrorMessages("Input cant be empty!!"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(OutPut.PrintErrorMessages(e.Message));
                }
                finally
                {
                    if (willContinue.Equals(true))
                        Console.ReadKey();

                    Console.Clear();
                }

            }

        }

        private static bool MainMenuNavigation(int userInput)
        {
            if (!userInput.Equals(ExitProgram))
            {
                string url = string.Empty;
                string input = string.Empty;
                Console.Clear();
                Console.WriteLine(InPut.InPutString(userInput));
                Console.ReadKey();
                willContinue = true;
            }
            else
            {
                willContinue = false;
            }
            return willContinue;
        }

        private static bool MainMenu()
        {
            Threads.StartThreadWithJoin(new Thread(new ThreadStart(OutPut.PrintMenuFrame)));
            Threads.StartThreadWithJoin(new Thread(new ThreadStart(OutPut.PrintMainMenu)));
            return willContinue = Menu.MainMenuNavigation(int.Parse(Console.ReadLine()));// if false program will close
        }
    }
}
