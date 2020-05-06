using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Licenta2.Models;
using Licenta2.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
                regiuneMontanaViewModel.ComentariiViewModel.IsBusy = true;
            }
        }
    }
}