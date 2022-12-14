using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model
{
    public class CExcelResp
    {
        public string IDCarga { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string RutEntrega { get; set; }
        public string NombreDestinatario { get; set; }
        public string ApellidoPaternoDestinatario { get; set; }
        public string ApellidoMaternoDestinatario { get; set; }
        public string CodProdOT { get; set; }
        public string TipoEntrega { get; set; }
        public string EmailEntrega { get; set; }
        public string CelularEntrega { get; set; }
        public string ValorDeclaradoProducto { get; set; }
        public string TipoArticulo { get; set; }
        public string GlsContenido { get; set; }
        public string DescripcionContenido { get; set; }
        public string CoberturaExtendida { get; set; }
        public string GlsCobertura { get; set; }
        public string GlsCalle { get; set; }
        public string GlsNumeracion { get; set; }
        public string GlsComplemento { get; set; }
        public string LargoPza { get; set; }
        public string AnchoPza { get; set; }
        public string AltoPza { get; set; }
        public string PesoOT { get; set; }
        public decimal NroOT { get; set; }
    }
}
