using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DescoperaMuntii.Models;
using DescoperaMuntii.ViewModels;
using DescoperaMuntii;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace DescoperaMuntii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreasPage : ContentPage
    {
        public AreasPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            RegiuniMontane regiune = new RegiuniMontane()
            {

                Comentarii = Comentariu.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegiuniMontane>();

                int rows = conn.Insert(regiune);


                if (rows > 0)
                {
                    DisplayAlert("Felicitări!", "Comentariu adăugat cu succes!", "ok");
                }
                else
                {
                    DisplayAlert("Eroare", "Comentariul nu a putut fi adăugat", "Încercați mai târziu");
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegiuniMontane>();
                var regiuni = conn.Table<RegiuniMontane>().ToList();
                regiuniListView.ItemsSource = regiuni;
               
            }
        }


    }

}
