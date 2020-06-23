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
        private const string URL= "http://api.openweathermap.org/data/2.5/weather?q=";
        private const string APIKEY = "&appid=199fefc6e88c9173d5f50323d8592652";
      
        public async Task<WeatherData> GetAPIData(string userInput)
        {
            WeatherData weatherData = new WeatherData();
            string path = URL + userInput + APIKEY;
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(path))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                var sysData = JObject.Parse(data);
                                weatherData = HandleDataFormat.ConvertJson(weatherData,sysData);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(e);
            }
            return weatherData;
        }
    }


}
