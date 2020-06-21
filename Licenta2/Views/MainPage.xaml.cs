using Licenta2.Models;
using Licenta2.Services;
using Licenta2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Licenta2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {

        INotificationManager notificationManager;
        RegiuniMontaneViewModel regiuniMontaneViewModel;

        public MainPage()
        {
            InitializeComponent();
            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
            regiuniMontaneViewModel = new RegiuniMontaneViewModel();
            checkBadWeather();

        }

        public async void checkBadWeather()
        {
            await regiuniMontaneViewModel.ExecuteLoadRegiuniMontaneCommand();
            var regiuniMontane = regiuniMontaneViewModel.RegiuniMontane;
            List<RegiuneMontana> regiuniFavorite = new List<RegiuneMontana>();
            foreach(RegiuneMontana regiuneMontana in regiuniMontane)
            {
                if(regiuneMontana.favorit)
                {
                    regiuniFavorite.Add(regiuneMontana);
                }
            }
            WeatherViewModel weatherViewModel;
            foreach (RegiuneMontana regiuneFavorita in regiuniFavorite)
            {
                weatherViewModel = new WeatherViewModel(regiuneFavorita.Locatie);
                weatherViewModel.DisplayableElementsCount = 40;
                await weatherViewModel.getWeatherAsync();
                ObservableCollection<WeatherData> forecast = weatherViewModel.WeatherForecast;
                List<WeatherData> filteredForecast = new List<WeatherData>();
                foreach(WeatherData weatherData in forecast)
                {
                        if(weatherData.Weather[0].Conditions.Contains("Rain") || weatherData.Weather[0].Conditions.Contains("Extreme"))
                        {
                        break;
                        }
                    
                }
                
                    string title = $"Bad weather in your favorite location!";
                    string message = $"{regiuneFavorita.Nume}";
                    notificationManager.ScheduleNotification(title, message);
                
            }
            
        }

        void ShowNotification(string title, string message)
        {
            //Device.BeginInvokeOnMainThread(() =>
            // {
            NotificationPage.addNotification(title, message);
            //   DisplayAlert(title, message, "Ok");
           // });
        }
    }
}