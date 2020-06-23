using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Data;
namespace WeatherApp
{
    class Program
    {   //API Im working with
        //http://api.openweathermap.org/data/2.5/weather?q=London&appid=199fefc6e88c9173d5f50323d8592652
        //https://openweathermap.org/current
        static async Task Main(string[] args)
        {
            await Menu.RunProgram();
        }

    }
}
