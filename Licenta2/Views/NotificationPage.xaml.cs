using Licenta2.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Licenta2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Licenta2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NotificationPage : ContentPage
    {
        static List<String> notifications = new List<String>();
        public Command ReloadCommand { get; set; }
        public NotificationPage()
        {
            InitializeComponent();
            BindingContext = this;
            IsBusy = false;
            ReloadCommand = new Command( () => ExecuteReloadCommand());
            
            foreach (String notification in notifications)
            {
                stackLayout.Children.Add(new Label() { Text = notification });
            }
        }

        public static void addNotification(string title, string message)
        {


            var Text = $"Notification Received:\nTitle: {title}\nMessage: {message}";

            notifications.Add(Text);

        }





        public void ExecuteReloadCommand()
        {
            IsBusy = true;
            stackLayout.Children.Clear();
            if(notifications.Count == 0)
            {
                stackLayout.Children.Add(new Label() { Text = "No new stuff for now" });
            }
            foreach (String notification in notifications)
            {
                stackLayout.Children.Add(new Label() { Text = notification });
            }
            
            IsBusy = false;
            
        
    }
}
}