using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        EditArtistDb editeartist = new EditArtistDb();
        //private ObservableCollection<OfflineSong> _songs;
        List<Artists> _artists;
        List<Track> _songs;
        List<GlobalSearch> _globalS;

        public StartPage()
        {
            InitializeComponent();
            description.Text = "Warning ! Aceasta aplicatie a fost facuta in scop educativ si nu este permisa incarcarea sau distribuirea acesteia cu alt scop decat acesta.";
            description1.Text = "Bun venit in RoTabs. Aplicatia viitorului in The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards. materie de tabulaturi romanesti";
            description2.Text = "Bun venit in RoTabs. Aplicatia viitorului in The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards. materie de tabulaturi romanesti";
            var firstLaunch = VersionTracking.IsFirstLaunchEver;

            if (firstLaunch == true)
            {
                welcome_mesage.Text = "Welcome to RoTabs!";
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocationOfflineSongs);
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            //SQLiteConnection conn = editeartist.OpenConnection();
            //conn.CreateTable<Artists>();
           // conn.CreateTable<Track>();

            _artists = conn.Table<Artists>().ToList();
            _songs = conn.Table<Track>().ToList();
            _globalS = makeLista(_artists, _songs);
            allListView.ItemsSource = _globalS;
            allListView.IsVisible = false;
            conn.Close();

        }

        private List<GlobalSearch> makeLista(List<Artists> artists, List<Track> tracks)
        {
            List<GlobalSearch> globals = new List<GlobalSearch>();
            GlobalSearch glob;
            foreach (Artists art in artists)
            {
                glob = new GlobalSearch(art);
                globals.Add(glob);
            }

            foreach (Track track in tracks)
            {
                glob = new GlobalSearch(track);
                globals.Add(glob);
            }

            return globals;
        }

        private void searchBarGlobaly_TextChanged(object sender, TextChangedEventArgs e)
        {


            allListView.ItemsSource = GetArtists(e.NewTextValue);
            if (GetArtists(e.NewTextValue) == null)
            {

                allListView.IsVisible = false;
            }
            else
            {
                allListView.IsVisible = true;
                principalStack.IsVisible = false;
            }
        }



        private IEnumerable GetArtists(string newTextValue)
        {
            //List<GlobalSearch> art = editeartist.createList();
           

            if (String.IsNullOrWhiteSpace(newTextValue))
                return null;
            return _globalS.Where(c => c.Name.StartsWith(newTextValue, true, null));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OfflineSongs());
        }

        private async void allListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var glob = e.SelectedItem as GlobalSearch;

                if (glob.a == 1)
                    await Navigation.PushAsync(new songList(glob.artist));
                else if (glob.t == 1)
                    await Navigation.PushAsync(new TrackPage(glob.track));
                else
                    await DisplayAlert("Don't Work", "warning ", "OK");


            }

            allListView.SelectedItem = null;
            searchBarGlobaly.Text = "";
            allListView.IsVisible = false;

        }
    }
}