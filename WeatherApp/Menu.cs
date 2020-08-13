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
        private const int menuX = 44;
        private const int menuY = 10;
        private static Thread threadOne = new Thread(new ThreadStart(RunProgram));
        private static Thread threadTwo = new Thread(new ThreadStart(OutPut.PrintMenuFrame));
        private static Thread threadThree = new Thread(new ThreadStart(OutPut.PrintMainMenu));

        public static void Main()
        {
            threadOne.Start();
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
                    Console.Clear();
                    OutPut.PrintMenuFrame();
                    ColorAndStyle.SetTextColor(Colors.red, string.Empty);
                    Console.WriteLine(ColorAndStyle.SetTextPosition("Input cant be empty!!", menuX, menuY));
                }
                catch (Exception e)
                {
                    Console.Clear();
                    OutPut.PrintMenuFrame();
                    ColorAndStyle.SetTextColor(Colors.red, string.Empty);
                    Console.WriteLine(ColorAndStyle.SetTextPosition(e.Message, menuX, menuY));
                }
                finally
                {
                    if (willContinue.Equals(true))
                        Console.ReadKey();

                    Console.Clear();
                }

            }

        }

        private static bool MainMenu()
        {
            threadTwo.Start();
            threadTwo.Join();
            threadThree.Start();
            threadThree.Join();

            return willContinue = Menu.MainMenuNavigation(int.Parse(Console.ReadLine()));// if false program will close
        }
    }
}
