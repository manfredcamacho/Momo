using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Momo.Models;
using System.Reflection;
using Java.Util;
using System;
using System.Linq;

namespace Momo.Tools
{
    public static class JsonTools
    {
        private static List<ImagenModel> listaImagenes;        
        private static List<PreguntaModel> listaPreguntas;

        public  static void cargarDatosJson()
        {
            var assembly = typeof(JsonTools).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Momo.preguntas.json");
            string json = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            listaImagenes = JsonConvert.DeserializeObject<List<ImagenModel>>(json);
            List<OpcionModel> listaOpciones;

            listaPreguntas = new List<PreguntaModel>();
            foreach (var imagen in listaImagenes)
            {
                listaOpciones = getOpciones(imagen);
                listaPreguntas.Add( new PreguntaModel(imagen, listaOpciones));
            }
        }

        public static PreguntaModel getPregunta(int numeroPregunta)
        {
            if (numeroPregunta <= cantidadPreguntas())
            {
                return listaPreguntas[numeroPregunta - 1];
            }
            else
            {
                //Si pide un numero de pregunta que no existe devuelvo la primer pregunta
                return listaPreguntas[0];
            }
            
        }

        public static int cantidadPreguntas()
        {
            return listaPreguntas.Count;
        }

        //Devuelvo las opciones para una imagen, incluyendo la respuesta correcta
        private static List<OpcionModel> getOpciones(ImagenModel imagen)
        {
            Java.Util.Random randomGen = new Java.Util.Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            List<int> listaNumeros = new List<int>();
            List<OpcionModel> listaOpciones = new List<OpcionModel>();
            
            //Genero un numero entre 1 y N (cantidad de imagenes)
            int numero = randomGen.NextInt(listaImagenes.Count) + 1 ;
            bool numeroRepetido = false;

            listaNumeros.Add(imagen.Id);

            //Agrego numeros a la lista hasta que tenga 4 numeros sin repetir
            while (listaNumeros.Count < 4 )
            {
                //Comparo  el numero generado con el resto de la lista 
                //y termina cuando compara a todos o encuentra un numero repetido
                for (int i = 0; i < listaNumeros.Count && !numeroRepetido; i++)
                {
                    if (listaNumeros[i] == numero)
                    {
                        numeroRepetido = true;
                    }
                }

                //Si el numero no es repetido lo agrego a la lista
                if (!numeroRepetido )
                {
                    listaNumeros.Add(numero);
                }
                numero = randomGen.NextInt(listaImagenes.Count) + 1;
                numeroRepetido = false;
            }

            //Creamos la lista de opciones
            bool opcionValida = false;
            Dictionary<Idiomas, string> contenidosOpcion;

            for (int i = 0; i < 4; i++)
            {
                contenidosOpcion = listaImagenes[listaNumeros[i] - 1].Nombre;
                if (listaImagenes[listaNumeros[i] - 1].Id == imagen.Id)
                {
                    opcionValida = true;
                }
                listaOpciones.Add(new OpcionModel { Contenido = contenidosOpcion, Valida = opcionValida});
                opcionValida = false;
            }

            return listaOpciones;
        }

        
        
    }
}
