using System;
using System.Collections.Generic;
using System.Text;

namespace ValidarExcel.Model.GenerarCarro
{
    public class GenerarCarroRequest
    {
        public decimal TotalValorCarro { get; set; }
        public int CantidadItem { get; set; }
        public int TipoDescuento { get; set; }
        public int ValorDescuento { get; set; }
        public string CodCupon { get; set; }
        public int IDCliente { get; set; }
        public int IDClientePago { get; set; }
        public int IDMedioPago { get; set; }
        public int NumeroDocumentoTributario { get; set; }
        public string DocId { get; set; }
        public decimal ValorTotalCobrado { get; set; }
        public string TipoBilletera { get; set; }
        public string CodAutorizacionPago { get; set; }
        public string NombreBilletera { get; set; }
        public string NumBilletera { get; set; }
    }
}
