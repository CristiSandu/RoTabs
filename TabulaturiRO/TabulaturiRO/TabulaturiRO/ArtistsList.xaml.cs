﻿using System;
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
            artistListView.ItemsSource = editeartist.createList();
        }

        private async void artistListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
               await Navigation.PushAsync(new songList
                {
                    BindingContext = e.SelectedItem as Artists
                });
            }
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

            return artists.Where(c => c.Name.StartsWith(newTextValue));
        }
    }
}