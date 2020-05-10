using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Licenta2.Models;
using Licenta2.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Licenta2.Services;

namespace Licenta2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RegiuneMontanaPage : ContentPage
    {
        RegiuneMontanaViewModel regiuneMontanaViewModel;
        Boolean mustRefresh = false;



        public RegiuneMontanaPage(RegiuneMontanaViewModel regiuneMontanaViewModel)
        {
            InitializeComponent();

            BindingContext = this.regiuneMontanaViewModel = regiuneMontanaViewModel;
        }

        public RegiuneMontanaPage()
        {
            InitializeComponent();


            var item = new RegiuneMontana
            {
                Locatie = "Borsa",
                Nume = "Item 1",
                Descriere = "This is an item description.",
                Comentarii = new List<Comentariu>()
            };

            regiuneMontanaViewModel = new RegiuneMontanaViewModel(item);
            BindingContext = regiuneMontanaViewModel;
        }

        async void SaveButton_ClickedAsync(object sender, EventArgs e)
        {
            regiuneMontanaViewModel.ComentariiViewModel.ComentariuNou.Data = DateTime.Now;
            await App.ComentariuDatabase.SaveOrUpdateComentariuAsync(regiuneMontanaViewModel.ComentariiViewModel.ComentariuNou);
            regiuneMontanaViewModel.ComentariiViewModel.resetComentariuNou();
            mustRefresh = true;
            this.OnAppearing();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (mustRefresh || regiuneMontanaViewModel.ComentariiViewModel.Comentarii.Count == 0)
            {
                regiuneMontanaViewModel.WeatherViewModel.retrieveWeatherFromAPI();
                regiuneMontanaViewModel.ComentariiViewModel.IsBusy = true;
            }
        }

        private void LoadMoreButton_Clicked(object sender, EventArgs e)
        {
          
                regiuneMontanaViewModel.WeatherViewModel.DisplayableElementsCount +=7;
                if(regiuneMontanaViewModel.WeatherViewModel.DisplayableElementsCount >= regiuneMontanaViewModel.WeatherViewModel.WeatherData.Weather.Length - 1)
                {
                DisplayAlert("Attention", "No more data available", "Ok");
                }
                this.mustRefresh = true;
                OnAppearing();
        }
    }
}