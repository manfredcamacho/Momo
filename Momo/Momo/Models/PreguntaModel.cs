using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo.Models
{
    public class PreguntaModel
    {
        public int Id { get; set; }
        public ImagenModel Imagen { get; set; }
        public List<OpcionModel> ListaOpciones { get; set; }

        public PreguntaModel(ImagenModel imagen, List<OpcionModel> listaOpciones)
        {
            this.Imagen = imagen;
            this.ListaOpciones = listaOpciones;
        }
    }
}
