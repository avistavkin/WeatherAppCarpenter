﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Data
{
        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            //public Clouds clouds { get; set; }
            public Wind wind { get; set; }
            public int visibility { get; set; }
            public double pop { get; set; }
            //public Sys sys { get; set; }
            public string dt_txt { get; set; }
            //public Rain rain { get; set; }

        }
    
}
