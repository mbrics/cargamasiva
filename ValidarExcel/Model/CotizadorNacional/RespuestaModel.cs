using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    [DataContract(IsReference = false)]
    public class RespuestaModel
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public bool resultado { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string respuesta { get; set; }

        public RespuestaModel()
        {

        }

        public RespuestaModel(RespuestaModel model) : this()
        {
            this.resultado = model.resultado;
            this.respuesta = model.respuesta;
        }

        public static implicit operator RespuestaModel(Articulo v)
        {
            throw new NotImplementedException();
        }
    }
}
