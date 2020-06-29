﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Data
{
    public class WeatherData
    {
        [JsonPropertyName("name")]
        public string CountryName { get; set; } 
        public string temp { get; set;}
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string windSpeed { get; set; }
        public string deg { get; set; }
        public string lon { get; set; }
        public string lat { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> weather { get; set; }

        public override string ToString()
        {
            return $"Lon: {lon}\nLat: {lat}\nCity: {CountryName}\nTempratura: {temp}C° \nPressure: {pressure}\n" +
                $"Humidity: {humidity}\nWind Speed: {windSpeed}\nDeg: {deg}\n" +
                $"Condition: {weather[0].main}\nDescription: {weather[0].description}";
        }
    }
}
