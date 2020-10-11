using SQLite;
using System;
using System.Collections;
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
    public partial class StartPage : ContentPage
    {
        EditArtistDb editeartist = new EditArtistDb();
        private ObservableCollection<OfflineSong> _songs;

        public StartPage()
        {
            InitializeComponent();
            description.Text = "Bun venit in RoTabs. Aplicatia viitorului in The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards. materie de tabulaturi romanesti";
            description1.Text = "Bun venit in RoTabs. Aplicatia viitorului in The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards. materie de tabulaturi romanesti";
            description2.Text = "Bun venit in RoTabs. Aplicatia viitorului in The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards.The Frame class inherits from ContentView, which means it can contain any type of View object including Layout objects. This ability allows the Frame to be used to create complex UI objects such as cards. materie de tabulaturi romanesti";

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocationOfflineSongs);
            conn.CreateTable<OfflineSong>();
            var songs = conn.Table<OfflineSong>().ToList();
            _songs = new ObservableCollection<OfflineSong>(songs);
            allListView.IsVisible = false;
            conn.Close();

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
            List<Artists> art = editeartist.createList();
            if (String.IsNullOrWhiteSpace(newTextValue))
                return null;
            return art.Where(c => c.Name.StartsWith(newTextValue, true, null));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OfflineSongs());
        }

        private async void allListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var art = e.SelectedItem as Artists;
                await Navigation.PushAsync(new songList(art));
            }

            allListView.SelectedItem = null;
            searchBarGlobaly.Text = "";
            allListView.IsVisible = false;

        }
    }
}