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
    public partial class MainPage : TabbedPage
    {

        EditArtistDb artistdb = new EditArtistDb();
        public MainPage()
        {
            InitializeComponent();
           

        }

        private async void saveOffline_Clicked(object sender, EventArgs e)
        {

            // HttpResponseMessage response = await client.GetAsync(firstPage.Source);
            //firstPage.Source


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
