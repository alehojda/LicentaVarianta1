using DescoperaMuntii.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DescoperaMuntii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AreasPage());

            RegiuniMontane regiuni = new RegiuniMontane()
            {
                Comentarii = addComentariu.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegiuniMontane>();

                int rows = conn.Insert(regiuni);


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
    }
}