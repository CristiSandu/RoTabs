using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<OfflineSong> _songs;
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
            _songs = new ObservableCollection<OfflineSong>(songs);
            listOfflineSongs.ItemsSource = _songs;
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

        private async void deleteSong_Clicked(object sender, EventArgs e)
        {
            var but = sender as Button;
            var song = but.BindingContext as OfflineSong;

            bool answer = await DisplayAlert("Question?", "Would you like to delete this offline song?", "Yes", "No");

            if (answer == true)
            {

                SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocationOfflineSongs);
                conn.CreateTable<OfflineSong>();
                if (song != null)
                {
                    conn.Delete(song);
                    var songs = conn.Table<OfflineSong>().ToList();
                    _songs = new ObservableCollection<OfflineSong>(songs);
                    listOfflineSongs.ItemsSource = _songs;
                }
                conn.Close();
            }



        }
    }
}