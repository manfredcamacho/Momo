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
            Respuesta = new Opcion { Nombre = "Goat" };
            Imagen = "https://openclipart.org/image/2400px/svg_to_png/17824/lemmling-Cartoon-goat.png";
            List<Opcion> opciones = new List<Opcion>();
            opciones.Add(new Opcion{ Nombre = "Dog"});
            opciones.Add(new Opcion { Nombre = "Rhino" });
            opciones.Add(new Opcion { Nombre = "Frog" });
            opciones.Add(Respuesta);

            opciones_lst.ItemsSource = opciones;

            pista_lbl.Text = Pista;
            imagen_img.Source = Imagen;
        }

        private void opciones_lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("MSG", ((Opcion)e.SelectedItem).Nombre, "OK");
        }

        private void pista_swch_Toggled(object sender, ToggledEventArgs e)
        {
            pista_lbl.IsVisible = e.Value;
        }
    }

    public class Opcion
    {
        public string Nombre { get; set; }
    }
}
