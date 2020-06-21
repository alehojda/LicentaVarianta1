using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Licenta2.Models;
using Licenta2.Views;
using Licenta2.ViewModels;

namespace Licenta2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RegiuniMontanePage : ContentPage
    {
        RegiuniMontaneViewModel viewModel;

        public RegiuniMontanePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RegiuniMontaneViewModel();
            //var assembly = typeof(RegiuniMontanePage);
            //if (favorit)
            //starIcon.Source = ImageSource.FromResource("empty.png", assembly);

        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (RegiuneMontana)layout.BindingContext;
            await Navigation.PushAsync(new RegiuneMontanaPage(new RegiuneMontanaViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRegiuneMontanaPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.RegiuniMontane.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}