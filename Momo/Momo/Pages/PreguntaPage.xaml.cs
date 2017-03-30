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
    public partial class PreguntaPage : ContentPage
    {
        Opcion Respuesta { get; set; }  
        string Pista { get; set; }
        string Imagen { get; set; }

        public PreguntaPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Pista= "Cabra";
            Respuesta = new Opcion { Nombre = "Goat", Valida = true };
            Imagen = "https://openclipart.org/image/2400px/svg_to_png/17824/lemmling-Cartoon-goat.png";
            List<Opcion> opciones = new List<Opcion>();
            opciones.Add(new Opcion{ Nombre = "Dog", Valida = false});
            opciones.Add(new Opcion { Nombre = "Rhino" , Valida = false});
            opciones.Add(new Opcion { Nombre = "Frog", Valida = false });
            opciones.Add(Respuesta);

            opciones_lst.ItemsSource = opciones;

            pista_lbl.Text = Pista;
            imagen_img.Source = Imagen;
        }

        private void opciones_lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((Opcion)e.SelectedItem).Valida)
            {
                Navigation.PushAsync(new Correcto());
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
    }

    public class Opcion
    {
        public string Nombre { get; set; }
        public Boolean Valida { get; set; }
    }
}
