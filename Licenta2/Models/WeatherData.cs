using System;
using System.Collections.Generic;
using System.Text;
using Licenta2.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Licenta2.Models
{
    public class WeatherData
    {

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("dt_txt")]
        public string Datetime { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Conditions { get; set; }

        [JsonProperty("description")]
        public string ConditionsDetails { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
        public ImageSource _IconSource;
        public ImageSource IconSource
        {
            get {
                var assembly = typeof(RegiuneMontanaPage);
                return Xamarin.Forms.ImageSource.FromResource("Licenta2.Assets.Images." + this.Icon + ".png", assembly); }
            set {
                var assembly = typeof(RegiuneMontanaPage);
                _IconSource = ImageSource.FromResource("Licenta2.Assets.Images." + this.Icon + ".png", assembly); }
        }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }

    }
}

