using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Licenta2.Models;

namespace Licenta2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewRegiuneMontanaPage : ContentPage
    {
        public RegiuneMontana RegiuneMontana { get; set; }

        public NewRegiuneMontanaPage()
        {
            InitializeComponent();

            RegiuneMontana = new RegiuneMontana
            {
                Locatie = "",
                Nume = "",
                Descriere = "",
                Comentarii = new List<Comentariu>()
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await App.RegiuneMontanaDatabase.SaveOrUpdateRegiuneMontanaAsync(RegiuneMontana);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
