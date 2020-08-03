using System;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class FetchData
    {
        #region url varibles
        private const string URL= "http://api.openweathermap.org/data/2.5/";
        private const string APIKEY = "&appid=199fefc6e88c9173d5f50323d8592652";
        private const string MetricUnits = "&units=metric";
        private const int GrabDailyForeCastData = 4;
        private const int GrabWeeklyForeCastData = 5;
        private const int GrabWeatherData = 1;
        #endregion

        private WeatherData weatherData = new WeatherData();
        #region creating url and connecting to client
        public async Task <WeatherData> GetAPIResponse(string userInput, int value)//grab data by city name
        {
            if (value.Equals(GrabWeatherData))
            {
                string weatherForCity = $"weather?q=+{userInput}";
                string path = URL + weatherForCity + MetricUnits + APIKEY;
                try
                {
                    weatherData = await ConnectToClient(path);
                }catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            else if (value.Equals(GrabDailyForeCastData) || value.Equals(GrabWeeklyForeCastData))
            {
                string weatherForCity = $"forecast?q={userInput}";
                string path = URL + weatherForCity + MetricUnits +APIKEY;

                try
                {
                    weatherData = await ConnectToClient(path);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            return weatherData;
        }


        public async Task<WeatherData> GetAPIResponse(int lat, int lon)//grab data by coords
        {
            string weatherForCoord = $"weather?lat={lat}&lon={lon}";
            string path = URL + weatherForCoord + MetricUnits + APIKEY;
            weatherData = await ConnectToClient(path);
            return weatherData;
        }

        #endregion

        #region connecting to api and grabbing a response string
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
                            var response = await content.ReadAsStringAsync();
                            if(response.Contains("404").Equals(true))
                            {
                                throw new Exception("No data found, wrong input ?");
                            }
                            else
                            {
                                weatherData = HandleDataFormat.DeserializeJsonObject(response);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return weatherData;
        }
    #endregion
    }


}
