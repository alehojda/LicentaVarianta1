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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            var assembly = typeof(LoginPage);
            registerImage.Source = ImageSource.FromResource("Licenta2.Assets.Images.logo2.jpg", assembly);
            BindingContext = this;

        }

        private void SigninButton_Clicked(object sender, EventArgs e)
        { 

            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                DisplayAlert("Eroare", "Completează toate câmpurile", "Ok");

                Navigation.InsertPageBefore(new RegisterPage(), this);
                Navigation.PopAsync();

            }
            else
            {
                Utilizator UtilizatorNou = new Utilizator
                {
                    Nume = NumeEntry.Text,
                    Prenume = PrenumeEntry.Text,
                    Email = EmailEntry.Text,
                    PhoneNumber = PhoneNumerEntry.Text,
                    Password = PasswordEntry.Text
                };
                DisplayAlert("Felicitări!", "Te-ai înregistrat cu succes!", "Ok");
                App.UtilizatorDatabase.SaveOrUpdateUtilizatorAsync(UtilizatorNou);
                Navigation.InsertPageBefore(new LoginPage(), this);
                Navigation.PopAsync();

            }

        }
    }
    
}