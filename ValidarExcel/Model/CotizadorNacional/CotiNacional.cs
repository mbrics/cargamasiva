using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    public class CotiNacional
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public int? COD_SERVICIO { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string NOM_SERVICIO { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public int? COD_PRODUCTO { get; set; }
        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public decimal? VALOR_NORMAL { get; set; }
        [DataMember(Order = 5)]
        [JsonProperty(Order = 5)]
        public decimal? PORCENTAJE_SERVICIO { get; set; }
        [DataMember(Order = 6)]
        [JsonProperty(Order = 6)]
        public decimal? TASA_ORIGEN { get; set; }
        [DataMember(Order = 7)]
        [JsonProperty(Order = 7)]
        public decimal? TASA_DESTINO { get; set; }
        [DataMember(Order = 8)]
        [JsonProperty(Order = 8)]
        public int? TIPO_TARIFA { get; set; }
        [DataMember(Order = 9)]
        [JsonProperty(Order = 9)]
        public int? COD_ERROR { get; set; }
        [DataMember(Order = 10)]
        [JsonProperty(Order = 10)]
        public string GLS_ERROR { get; set; }
        [DataMember(Order = 11)]
        [JsonProperty(Order = 11)]
        public decimal? VALOR { get; set; }
        [DataMember(Order = 12)]
        [JsonProperty(Order = 12)]
        public int? INDPESOVOL { get; set; }
        [DataMember(Order = 13)]
        [JsonProperty(Order = 13)]
        public decimal? PESO_CALCULO { get; set; }
        [DataMember(Order = 14)]
        [JsonProperty(Order = 14)]
        public int? CODIGO_CONTROL { get; set; }
        [DataMember(Order = 15)]
        [JsonProperty(Order = 15)]
        public string GLS_ENTREGA { get; set; }
        [DataMember(Order = 16)]
        [JsonProperty(Order = 16)]
        public int? VALOR_RETIRO { get; set; }
        [DataMember(Order = 17)]
        [JsonProperty(Order = 17)]
        public int? VALOR_EOL { get; set; }
        [DataMember(Order = 18)]
        [JsonProperty(Order = 18)]
        public string FEC_ENTREGA { get; set; }
        [DataMember(Order = 19)]
        [JsonProperty(Order = 19)]
        public List<ServAdicional> ListServAdicional { get; set; }

        public CotiNacional()
        {
            this.ListServAdicional = new List<ServAdicional>();
        }

        public CotiNacional(CotiNacional model) : this()
        {
            this.COD_SERVICIO = model.COD_SERVICIO;
            this.NOM_SERVICIO = model.NOM_SERVICIO;
            this.COD_PRODUCTO = model.COD_PRODUCTO;
            this.VALOR_NORMAL = model.VALOR_NORMAL;
            this.PORCENTAJE_SERVICIO = model.PORCENTAJE_SERVICIO;
            this.TASA_ORIGEN = model.TASA_ORIGEN;
            this.TASA_DESTINO = model.TASA_DESTINO;
            this.TIPO_TARIFA = model.TIPO_TARIFA;
            this.COD_ERROR = model.COD_ERROR;
            this.GLS_ERROR = model.GLS_ERROR;
            this.VALOR = model.VALOR;
            this.INDPESOVOL = model.INDPESOVOL;
            this.PESO_CALCULO = model.PESO_CALCULO;
            this.CODIGO_CONTROL = model.CODIGO_CONTROL;
            this.GLS_ENTREGA = model.GLS_ENTREGA;
            this.VALOR_RETIRO = model.VALOR_RETIRO;
            this.VALOR_EOL = model.VALOR_EOL;
            this.FEC_ENTREGA = model.FEC_ENTREGA;
            this.ListServAdicional = model.ListServAdicional;
        }
    }
}
