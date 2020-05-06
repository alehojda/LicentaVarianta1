using Licenta2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Licenta2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
      

        public LoginPage()
        {
            InitializeComponent();
            var assembly = typeof(LoginPage);

            iconImage.Source = ImageSource.FromResource("Licenta2.Assets.Images.logo1.jpg", assembly);
        }

        private void SigninButton_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RegisterPage(), this);
            Navigation.PopAsync();
        }

 
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);
            Utilizator UtilizatorLogin = await App.UtilizatorDatabase.GetUtilizatorByEmail(EmailEntry.Text);
            //List<Utilizator> u = await App.UtilizatorDatabase.GetUtilizatoriAsync();

            if (isEmailEmpty || isPasswordEmpty || UtilizatorLogin == null)
            {

            }
            else
            {
                if (!UtilizatorLogin.Password.Equals(PasswordEntry.Text))
                {
                    await DisplayAlert("Oops", "Parola introdusă nu este corectă!", "Ok");
                }
                else
                {
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
            }
        }
    }
}