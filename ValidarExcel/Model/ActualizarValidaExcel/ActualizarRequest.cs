using System;
using System.Collections.Generic;
using System.Text;

namespace ValidarExcel.Model.ActualizarValidaExcel
{
    public class ActualizarRequest
    {
        public int IDCarga { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string Sucursal { get; set; }
        public int EstadoCotizador { get; set; }
        public int EstadoDirOrigen { get; set; }
        public int EstadoDirDestino { get; set; }
        public int EstadoSucursal { get; set; }
        public string CodOrigen { get; set; }
        public string CodDestino { get; set; }
        public decimal TotalValor { get; set; }
        public string TipoEntrega { get; set; }
        public int EstadoDireccion {get;set;}
        public string GlsCalle { get; set; }
        public string GlsNumeracion { get; set; }

        public ActualizarRequest()
        {
            this.CodOrigen = "";
            this.CodDestino = "";
            this.TotalValor = 0;
        }
    }
}
