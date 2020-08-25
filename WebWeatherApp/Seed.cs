using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;
using WebWeatherApp.Models;

namespace WebWeatherApp
{
    public class Seed
    {
        public static async Task<WeatherData> PopulateWeatherModel(string city)
        {
            WeatherData cityName = new WeatherData();
            FetchData fetch = new FetchData();
            WeatherData weatherData = await fetch.GetAPIResponse(city,1);
            return weatherData;
        }
    }
}
