using Licenta2.Models;
using Licenta2.Services;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Licenta2.ViewModels
{
    public class WeatherViewModel
    {
        public string locationId;
        public int DisplayableElementsCount { get; set; }
        public WeatherForecast WeatherData { get; set; }
        public ObservableCollection<WeatherData> WeatherForecast { get; set; }
        public WeatherViewModel(string locationId)
        {
            this.DisplayableElementsCount = 1;
            this.locationId = locationId;
            this.WeatherData = null;
            WeatherForecast = new ObservableCollection<WeatherData>();
            _ = getWeatherAsync();
        }

        public async Task getWeatherAsync()
        {
            WeatherRestService weatherRestService = new WeatherRestService();
            string weatherUri = Constants.OpenWeatherMapEndpoint + locationId + Constants.OpenWeatherMapAPIKey;
            this.WeatherData = await weatherRestService.GetWeatherDataAsync(weatherUri);
            DisplayElements();
           
        }

        public void retrieveWeatherFromAPI()
        {
           
            DisplayElements();
        }
        public void DisplayElements()
        {
            if(this.WeatherData != null) {
                WeatherForecast.Clear();
            for (int i = 0; i < this.DisplayableElementsCount && i < this.WeatherData.Weather.Length; i++)
            {
                WeatherForecast.Add(this.WeatherData.Weather[i]);
              
            }
            }
        }
    }
}