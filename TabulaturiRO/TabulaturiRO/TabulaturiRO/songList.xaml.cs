using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class songList : ContentPage
    {
        int id_art = 0; 
        public songList()
        {
            InitializeComponent();

        }

        public songList(Artists art)
        {
            InitializeComponent();
            id_art = art.Id;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Track>();
            var tracks = conn.Table<Track>();
            List<Track> _tracks = new List<Track>();
            foreach (var item in tracks)
            {
                if (item.Artist_Id == id_art)
                {
                    _tracks.Add(item);
                }
            }

            if (_tracks.Count() == 0) 
            { 
                noSongLabel.IsVisible = true;
                backButton.IsVisible = true;
            }
            else
                tracksListView.ItemsSource = _tracks;
            searchBarTracks.IsVisible = true;
            conn.Close();
        }

        private void searchBarTracks_TextChanged(object sender, TextChangedEventArgs e)
        {
            tracksListView.ItemsSource = GetTracks(e.NewTextValue);
        }

        private IEnumerable GetTracks(string newTextValue)
        {

            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Track>();
            var tracks = conn.Table<Track>();
            List<Track> _tracks = new List<Track>();
            foreach (var item in tracks)
            {
                if (item.Artist_Id == id_art)
                {
                    _tracks.Add(item);
                }
            }
            conn.Close(); 
            if (String.IsNullOrWhiteSpace(newTextValue))
                return _tracks;
            return _tracks.Where(c => c.Title.StartsWith(newTextValue, true, null));
        }

        private async void tracksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TrackPage{
                    BindingContext = e.SelectedItem as Track
                });
            }
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}