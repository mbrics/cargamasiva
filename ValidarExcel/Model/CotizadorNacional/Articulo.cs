using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    [DataContract(IsReference = false)]
    public class Articulo
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public int? Codigo { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string Glosa { get; set; }

        public Articulo()
        {

        }
        public Articulo(Articulo model) : this()
        {
            this.Codigo = model.Codigo;
            this.Glosa = model.Glosa;
        }
    }
}
