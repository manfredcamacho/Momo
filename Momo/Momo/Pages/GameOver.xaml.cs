using Momo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Momo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameOver : ContentPage
    {
        public GameOver()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            if (PreguntaPage.Idioma == Idiomas.ing)
            {
                msg.Text = "GAME OVER";
            }
        }

        public void OnTapped(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
