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
    public partial class Incorrecto : ContentPage
    {
        public Incorrecto()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        
            if (PreguntaPage.Idioma == Idiomas.ing)
            {
                msg.Text = "¡¡¡TRY AGAIN!!!";
            }
        }
        protected async override void OnAppearing()
        {
            await msg.TranslateTo(2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(-2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(-2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(-2.5, 0, 50, Easing.Linear);
            await msg.TranslateTo(0, 0, 50, Easing.Linear);
            await msg.ScaleTo(2, 2000, Easing.CubicInOut);
        }
        public void OnTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
