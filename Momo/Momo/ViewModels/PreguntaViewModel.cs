using Momo.Models;
using Momo.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo.ViewModels
{
    class PreguntaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PreguntaModel pregunta;
        private int preguntaActual;

        public PreguntaViewModel(Idiomas idioma)
        {
            JsonTools.cargarDatosJson();
            preguntaActual = 1;
            pregunta = JsonTools.getPregunta(preguntaActual);

            Idioma = idioma;
            Pista = pregunta.Imagen.Nombre[setIdiomaPista(Idioma)];
            Imagen = pregunta.Imagen.Url;
            ListaOpciones = pregunta.ListaOpciones;            
            
        }

        public bool existePregunta(int numeroPregunta)
        {
            if (numeroPregunta > 0 && numeroPregunta <= JsonTools.cantidadPreguntas())
                return true;
            else
                return false;
        }

        public void cambiarPregunta(int numeroPregunta)
        {
            //getPregunta verifica si numeroPregunta es correcto
            pregunta = JsonTools.getPregunta(numeroPregunta);
            Pista = pregunta.Imagen.Nombre[setIdiomaPista(Idioma)];
            Imagen = pregunta.Imagen.Url;
            ListaOpciones = pregunta.ListaOpciones;
        }

        private Idiomas setIdiomaPista(Idiomas idioma)
        {
            if (idioma == Idiomas.esp)
                return Idiomas.ing;
            else
                return Idiomas.esp;
        }

        private Idiomas _idioma;
        public Idiomas Idioma
        {
            get { return _idioma; }
            set
            {
                if (_idioma != value)
                {
                    _idioma = value;
                    OnPropertyChanged("Idioma");
                }
            }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set
            {
                if(_imagen != value)
                {
                    _imagen = value;
                    OnPropertyChanged("Imagen");
                }
            }
        }

        private List<OpcionModel> _listaOpciones; 
        public List<OpcionModel> ListaOpciones
        {
            get { return _listaOpciones; }
            set
            {
                if (_listaOpciones != value)
                {
                    _listaOpciones = value;
                    OnPropertyChanged("ListaOpciones");
                }
            }
        }

        private string _pista;
        public string Pista
        {
            get { return _pista; }
            set
            {
                if (_pista != value)
                {
                    _pista = value;
                    OnPropertyChanged("Pista");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
