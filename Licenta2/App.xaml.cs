using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Licenta2.Services;
using Licenta2.Views;


namespace Licenta2
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;

        static RegiuneMontanaDatabaseService regiuneMontanaDatabase;
        public static RegiuneMontanaDatabaseService RegiuneMontanaDatabase
        {
            get
            {
                if (regiuneMontanaDatabase == null)
                {
                    regiuneMontanaDatabase = new RegiuneMontanaDatabaseService();
                }
                return regiuneMontanaDatabase;
            }
        }

        static ComentariuDatabaseService comentariuDatabase;
        public static ComentariuDatabaseService ComentariuDatabase
        {
            get
            {
                if (comentariuDatabase == null)
                {
                    comentariuDatabase = new ComentariuDatabaseService();
                }
                return comentariuDatabase;
            }
        }
        static UtilizatorDatabaseService utilizatorDatabase;
        public static UtilizatorDatabaseService UtilizatorDatabase
        {
            get
            {
                if (utilizatorDatabase == null)
                {
                    utilizatorDatabase = new UtilizatorDatabaseService();
                }
                return utilizatorDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Get<INotificationManager>().Initialize();

            MainPage = new NavigationPage(new LoginPage());

        }

    protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            var a = true;
        }

        protected override void OnResume()
        {
            var a = false;
        }
    }
}
