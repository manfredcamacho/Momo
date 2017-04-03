using Momo.Models;
using Momo.Tools;
using Momo.ViewModels;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Momo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaPage : ContentPage
    {
        Idiomas Idioma { get; set; }
        PreguntaViewModel pregunta;
        static int numeroPregunta;

        public PreguntaPage(Idiomas idioma)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            numeroPregunta = 1;
            this.Idioma = idioma;
            pregunta = new PreguntaViewModel(idioma);
            this.BindingContext = pregunta;            
        }

        private void opciones_lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (((OpcionModel)e.SelectedItem).Valida)
            {
                numeroPregunta++;
                if (pregunta.existePregunta(numeroPregunta))
                {
                    Navigation.PushAsync(new Correcto());
                    pregunta.cambiarPregunta(numeroPregunta);
                }
                else
                {
                    Navigation.PushAsync(new GameOver());
                }
                
            }
            else
            {
                Navigation.PushAsync(new Incorrecto());
            }
        }

        private void pista_swch_Toggled(object sender, ToggledEventArgs e)
        {
            pista_lbl.IsVisible = e.Value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
