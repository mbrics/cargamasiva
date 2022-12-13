using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    [DataContract(IsReference = false)]
    public class ServAdicional
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public int? COD_SERVICIO_ADICIONAL { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string NOMBRE_SERVICIO_ADICIONAL { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public bool? OBLIGATORIO { get; set; }
        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public decimal? VALOR_SERVICIO { get; set; }
        [DataMember(Order = 5)]
        [JsonProperty(Order = 5)]
        public decimal? VALOR_TOTAL { get; set; }

        public ServAdicional()
        {

        }

        public ServAdicional(ServAdicional model) : this()
        {
            this.COD_SERVICIO_ADICIONAL = model.COD_SERVICIO_ADICIONAL;
            this.NOMBRE_SERVICIO_ADICIONAL = model.NOMBRE_SERVICIO_ADICIONAL;
            this.OBLIGATORIO = model.OBLIGATORIO;
            this.VALOR_SERVICIO = model.VALOR_SERVICIO;
            this.VALOR_TOTAL = model.VALOR_TOTAL;
        }
    }
}
