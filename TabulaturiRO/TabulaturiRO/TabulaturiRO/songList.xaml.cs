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
        Artists _art;
        List<Track> _tracks = new List<Track>();
        public songList()
        {
            InitializeComponent();

        }

        public songList(Artists art)
        {
            InitializeComponent();
            _art = art;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            //conn.CreateTable<Track>();
            var tracks = conn.Table<Track>();

            
           

            if (_art == null)
            {
                _tracks = tracks.ToList();
            }
            else
            {
                var stocksStartingWithA = conn.Query<Track>("SELECT * FROM Track WHERE artist_id = ?", _art.Id);
                _tracks = stocksStartingWithA.ToList<Track>();

                if (_tracks.Count() == 0)
                {
                    noSongLabel.IsVisible = true;
                    backButton.IsVisible = true;
                }
                else
                    tracksListView.ItemsSource = _tracks;
            }

            searchBarTracks.IsVisible = true;
            searchBarTracks.Text = "";
            conn.Close();
        }

        private void searchBarTracks_TextChanged(object sender, TextChangedEventArgs e)
        {
            tracksListView.ItemsSource = GetTracks(e.NewTextValue);
        }

        private IEnumerable GetTracks(string newTextValue)
        {

          
            if (String.IsNullOrWhiteSpace(newTextValue))
                return _tracks;
            return _tracks.Where(c => c.Title.StartsWith(newTextValue, true, null));
        }

        private async void tracksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var track = e.SelectedItem as Track;
                await Navigation.PushAsync(new TrackPage(track));
            }
            tracksListView.SelectedItem = null;
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}