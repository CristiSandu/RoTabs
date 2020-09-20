using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfflineSongs : ContentPage
    {
        public OfflineSongs()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocationOfflineSongs);
            conn.CreateTable<OfflineSong>();
            var songs = conn.Table<OfflineSong>().ToList();
            listOfflineSongs.ItemsSource = songs;
            conn.Close();

        }

        private async void listOfflineSongs_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var send = e.SelectedItem as OfflineSong;
                await Navigation.PushAsync(new OfflineTrackPage(send));
            }
        }
    }
}