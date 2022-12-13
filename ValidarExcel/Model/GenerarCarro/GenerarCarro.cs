using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.GenerarCarro
{
    public class GenerarCarro
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public decimal Carro { get; set; }

        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public int Resultado { get; set; }

        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public string Mensaje { get; set; }
    }
}
