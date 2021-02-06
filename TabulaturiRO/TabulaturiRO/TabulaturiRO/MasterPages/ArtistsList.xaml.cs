using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistsList : ContentPage
    {
        EditArtistDb editeartist = new EditArtistDb();
        public ArtistsList()
        {
            InitializeComponent();
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var listArtists = editeartist.createList();
            artistListView.ItemsSource = listArtists;
            searchBarArtists.Placeholder = $"Search in {listArtists.Count} artists";
            searchBarArtists.Text = "";
        }

        private async void artistListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var art = e.SelectedItem as Artists;
                await Navigation.PushAsync(new songList(art));
            }
            artistListView.SelectedItem = null;
        }



        private void searchBarArtists_TextChanged(object sender, TextChangedEventArgs e)
        {
            artistListView.ItemsSource = GetArtists(e.NewTextValue);
        }

        private IEnumerable GetArtists(string newTextValue = null)
        {
           var artists = editeartist.createList();

            if (String.IsNullOrWhiteSpace(newTextValue))
                return artists;

            return artists.Where(c => c.Name.StartsWith(RemoveDiacritics(newTextValue),true,null));
        }


        public string RemoveDiacritics(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        private void artistListView_Refreshing(object sender, EventArgs e)
        {
            artistListView.ItemsSource = editeartist.createList();
            artistListView.EndRefresh();
        }
    }

}