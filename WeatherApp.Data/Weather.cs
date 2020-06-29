using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Data
{
    public class Weather
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("main")]
        public string main { get; set; }
        [JsonPropertyName("description")]
        public string description {get;set;}
        [JsonPropertyName("icon")]
        public string icon { get; set; }

        [JsonPropertyName("lon")]
        public int lon { get; set; }

        [JsonPropertyName("lat")]
        public int lat { get; set; }
    }
}
