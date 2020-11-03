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

            if (_index == 0)
                MainText.Text = " Bun venit la RoTabs Prima aplicatie de tabulaturi Romanesti \n \n Take a Toure!!";
            else
            {
                MainText.Text = "test" + _index;

            }
        }

        private async void start_Clicked(object sender, EventArgs e)
        {
            if (_index == 2)
                await Navigation.PushModalAsync(new MainPage());
            else
                await Navigation.PushModalAsync(new StartTutorial(_index + 1));

        }
    }
}