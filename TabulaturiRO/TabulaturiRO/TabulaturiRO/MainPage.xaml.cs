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
    public partial class MainPage : MasterDetailPage
    {

        EditArtistDb artistdb = new EditArtistDb();
        public MainPage()
        {
            InitializeComponent();
            masterPage.listView1.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.TargetType != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.listView1.SelectedItem = null;
                    IsPresented = false;
                }
            }
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
