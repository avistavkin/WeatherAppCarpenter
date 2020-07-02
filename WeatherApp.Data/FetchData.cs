using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class FetchData
    {
        #region url data
        private const string URL= "http://api.openweathermap.org/data/2.5/";
        private const string APIKEY = "&appid=199fefc6e88c9173d5f50323d8592652";
        private const string MetricUnits = "&units=metric";
        #endregion
        private WeatherData weatherData = new WeatherData();

        #region
        public async Task<WeatherData> GetAPIData(string userInput)//grab data by city name
        {
            string weatherForCity = $"weather?q=+{userInput}";
            string path = URL + weatherForCity + MetricUnits + APIKEY;
            weatherData = await ConnectToClient(path);
            return weatherData;
        }


        public async Task<WeatherData> GetAPIData(int lat, int lon)//grab data by coords
        {
            string weatherForCoord = $"weather?lat={lat}&lon={lon}";
            string path = URL + weatherForCoord + MetricUnits + APIKEY;
            //string path = "https://api.openweathermap.org/data/2.5/onecall?lat=57&lon=12&appid=199fefc6e88c9173d5f50323d8592652";//for onecall support
            weatherData = await ConnectToClient(path);
            return weatherData;

        }
        #endregion
        private async Task<WeatherData> ConnectToClient(string path)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(path))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                var sysData = JObject.Parse(data);//convert to json 
                                weatherData = HandleDataFormat.DeserializeJsonObject(sysData);
                            }
                            else
                            {
                                Console.WriteLine("NO Data");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("NO Data Found!");
            }

            return weatherData;
        }
    }


}
