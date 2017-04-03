using Newtonsoft.Json;
using System.Collections.Generic;

namespace Momo.Models
{
    public class ImagenModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "imagen")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "respuesta")]
        public Dictionary<Idiomas, string> Nombre { get; set; }
    }
}
