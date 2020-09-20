using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackPage : ContentPage
    {
        Track _track;
        public TrackPage()
        {
            InitializeComponent();
        }
        
        public TrackPage(Track track)
        {
            InitializeComponent();
            _track = track;
            //var htmlSource = new HtmlWebViewSource();
           // string source = song.HTML_Song;
           // htmlSource.Html = @track.html_dark;
            trackPage.Source = track.Link_Track;
        }

        private async void addToOfflineList_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string URL = _track.Link_Track;
            string content ="";
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            await DisplayAlert("ok", content, "ok");
            // await Navigation.PushAsync(new OfflineTrackPage(content));
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocationOfflineSongs);
            conn.CreateTable<OfflineSong>();
            OfflineSong song;
            SQLiteConnection conn2 = new SQLiteConnection(App.DataBaseLocation);


            if (content != "")
            {
                var stocksStartingWithA = conn2.Query<Artists>("SELECT * FROM Artists WHERE id = ?", _track.Artist_Id);
                var list = stocksStartingWithA.ToList<Artists>();
                string fullname = list[0].Name + " - " + _track.Title;
                song = new OfflineSong { Name_Song = fullname, HTML_Song = content, HTML_dark = _track.html_id };

                conn.Insert(song);
            }
            conn.Close();
        }
    }
}