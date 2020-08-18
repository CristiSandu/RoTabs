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
    public partial class StartPage : ContentPage
    {
        EditArtistDb editeartist = new EditArtistDb();

        public StartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private void searchBarGlobaly_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GetArtists(e.NewTextValue) == null)
            {
                
                allListView.ItemsSource = GetTracks(e.NewTextValue);
                if (GetTracks(e.NewTextValue) == null)
                    allListView.IsVisible = false;
                else
                    allListView.IsVisible = true;
            }
            else
            {
                allListView.ItemsSource = GetArtists(e.NewTextValue);
                if (GetArtists(e.NewTextValue) == null)
                    allListView.IsVisible = false;
                else
                    allListView.IsVisible = true; 
            }

        }

        private IEnumerable GetTracks(string newTextValue)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Track>();
            var tracks = conn.Table<Track>().ToList();
            if (String.IsNullOrWhiteSpace(newTextValue))
                return null;
            return tracks.Where(c => c.Title.StartsWith(newTextValue, true, null));
        }

        private IEnumerable GetArtists(string newTextValue)
        {
           List<Artists> art = editeartist.createList();
            if (String.IsNullOrWhiteSpace(newTextValue))
                return null;
                return art.Where(c => c.Name.StartsWith(newTextValue, true, null));
        }
    }
}