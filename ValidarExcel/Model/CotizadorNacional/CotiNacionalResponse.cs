using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    public class CotiNacionalResponse
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public List<CotiNacional> ListCotiNacional { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public RespuestaModel Respuesta { get; set; }

        public CotiNacionalResponse()
        {
            this.ListCotiNacional = new List<CotiNacional>();
        }

        public CotiNacionalResponse(CotiNacionalResponse model) : this()
        {
            this.ListCotiNacional = model.ListCotiNacional;
            this.Respuesta.resultado = model.Respuesta.resultado;
            this.Respuesta.respuesta = model.Respuesta.respuesta;
        }
    }
}
