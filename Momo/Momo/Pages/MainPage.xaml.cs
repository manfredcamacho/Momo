using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Momo.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void esp_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreguntaPage());
        }

        private void eng_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PreguntaPage());
        }

    }
}
