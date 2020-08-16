using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabulaturiRO
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        EditArtistDb artistdb = new EditArtistDb();
        public MainPage()
        {
            InitializeComponent();
            urlHolder.Text = "https://www.tabulaturi.ro/artisti";
            firstPage.Source = urlHolder.Text;

        }

        private async void saveOffline_Clicked(object sender, EventArgs e)
        {

            // HttpResponseMessage response = await client.GetAsync(firstPage.Source);
            //firstPage.Source


        }

        private void firstPage_Navigating(object sender, WebNavigatingEventArgs e)
        {

        }

        private void firstPage_Navigated(object sender, WebNavigatedEventArgs e)
        {

        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            if (firstPage.CanGoBack)
                firstPage.GoBack();
        }

        private void nextPageButton_Clicked(object sender, EventArgs e)
        {
            if (firstPage.CanGoForward)
                firstPage.GoForward();
        }

        private async void addPages_Clicked(object sender, EventArgs e)
        {
            string[] links = { "https://www.tabulaturi.ro/artisti/a-s-i-a",
                               "https://www.tabulaturi.ro/artisti/ab4",
                               "https://www.tabulaturi.ro/artisti/abcd",
                               "https://www.tabulaturi.ro/artisti/abra",
                               "https://www.tabulaturi.ro/artisti/abracadabra"
                             };

            string[] names = { "a-s-i-a",
                               "ab4",
                               "abcd",
                               "abra",
                               "abracadabra"
                             };

            for(int i = 0; i < 5; i++)
            {
                var art = new Artists { Name = names[i], Link = links[i] };
               
                artistdb.saveArtist(art);
            }
           
        }

        private async void deleteAll_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtistsList());
        }
    }
}


/*
 for lst in list_link :
        
        html = urlopen(lst, context=ctx).read()
        soup = BeautifulSoup(html, "html.parser")
        tags = soup('a')
        for tag in tags :
            if len(tag.get('href',None)) > 1 :
                if tag.get('href',None) in list_link:
                    continue 
                else :
                    list_link.append(tag.get('href',None))
                    print(tag.get('href',None))
 
 
 */
