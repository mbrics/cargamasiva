using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidarExcel.Model.CotizadorNacional
{
    public class ValNacionalRequest
    {
        [Required(ErrorMessage = "Ciudad de origen es requerido")]
        public string CIUDAD_ORIGEN { get; set; }
        [Required(ErrorMessage = "Ciudad de destino es requerido")]
        public string CIUDAD_DESTINO { get; set; }
        [Required(ErrorMessage = "Codigo de producto es requerido")]
        public int? COD_PRODUCTO { get; set; }
        [Required(ErrorMessage = "Peso es requerido")]
        public decimal? PESO { get; set; }
        public int? ALTO { get; set; }
        public int? ANCHO { get; set; }
        public int? LARGO { get; set; }
        public int? CODIGO_CONTROL { get; set; }
        public int? INDHORARIO { get; set; }
        public int? OFICINA_ORIGEN { get; set; }
        public int? OFICINA_DESTINO { get; set; }
        public DateTime? HORARIO_ADMISION { get; set; }
        public DateTime? FECHA_ORIGEN { get; set; }
        public decimal? COD_TCC_CLIENTE { get; set; }
        public int? CONT_TIEMPOENTREGA_BASE { get; set; }
        public int? IND_LDEV { get; set; }
        public decimal? VALOR_DECLARADO { get; set; }

        public ValNacionalRequest()
        {
            this.ALTO = 1;
            this.ANCHO = 1;
            this.LARGO = 1;
            this.CODIGO_CONTROL = 0;
            this.INDHORARIO = 0;
            this.OFICINA_ORIGEN = null;
            this.OFICINA_DESTINO = null;
            this.HORARIO_ADMISION = null;
            this.FECHA_ORIGEN = null;
            this.COD_TCC_CLIENTE = null;
            this.CONT_TIEMPOENTREGA_BASE = 0;
            this.IND_LDEV = null;
            this.VALOR_DECLARADO = null;
        }

        public ValNacionalRequest(ValNacionalRequest model) : this()
        {
            this.CIUDAD_ORIGEN = model.CIUDAD_ORIGEN;
            this.CIUDAD_DESTINO = model.CIUDAD_DESTINO;
            this.COD_PRODUCTO = model.COD_PRODUCTO;
            this.PESO = model.PESO;
            this.ALTO = model.ALTO;
            this.ANCHO = model.ANCHO;
            this.LARGO = model.LARGO;
            this.CODIGO_CONTROL = model.CODIGO_CONTROL;
            this.INDHORARIO = model.INDHORARIO;
            this.OFICINA_ORIGEN = model.OFICINA_ORIGEN;
            this.OFICINA_DESTINO = model.OFICINA_DESTINO;
            this.HORARIO_ADMISION = model.HORARIO_ADMISION;
            this.FECHA_ORIGEN = model.FECHA_ORIGEN;
            this.COD_TCC_CLIENTE = model.COD_TCC_CLIENTE;
            this.CONT_TIEMPOENTREGA_BASE = model.CONT_TIEMPOENTREGA_BASE;
            this.IND_LDEV = model.IND_LDEV;
            this.VALOR_DECLARADO = model.VALOR_DECLARADO;
        }
    }
}
