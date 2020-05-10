using Licenta2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Licenta2.Models
{
    public class WeatherForecast
    {
        [JsonProperty("list")]
        public WeatherData[] Weather { get; set; }
    }
}
