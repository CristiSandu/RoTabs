using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfflineTrackPage : ContentPage
    {
        public OfflineTrackPage()
        {
            InitializeComponent();
        }

        public OfflineTrackPage(OfflineSong song)
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource();
            string source = song.HTML_Song;
            htmlSource.Html = @source;
            offlineTrackPage.Source = htmlSource;
        }

    }
}