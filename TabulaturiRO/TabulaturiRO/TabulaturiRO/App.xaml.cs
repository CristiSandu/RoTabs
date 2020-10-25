using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TabulaturiRO
{
    public partial class App : Application
    {

        public static string DataBaseLocation = string.Empty;
        public static string DataBaseLocationOfflineSongs = string.Empty;

        public App()
        {
            InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track();

            MainPage = new MainPage();
        }

        public App(string dbName)
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();

            MainPage = new MainPage();
            DataBaseLocation = dbName;
        }


        public App(string dbName, string dbName2)
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();

            MainPage = new MainPage();
            DataBaseLocation = dbName;
            DataBaseLocationOfflineSongs = dbName2;
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
