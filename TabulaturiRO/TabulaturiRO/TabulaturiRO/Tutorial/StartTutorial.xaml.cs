using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabulaturiRO.Tutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartTutorial : ContentPage
    {
        int _index;
        public StartTutorial(int index)
        {
            InitializeComponent();
            _index = index;

            if (_index != 2)
            {
                start.IsVisible = false;
            }

            MainText.Text = "This is a test " + _index;
        }

        private async void start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage()); 
        }
    }
}