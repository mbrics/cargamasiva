using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ValidarExcel.Model;
using ValidarExcel.Modelo;
using System.Linq;
using ValidarExcel.Model.ActualizarValidaExcel;
using ValidarExcel.Model.CargarEstructura;
using System.Threading.Tasks;
using ValidarExcel.Model.ActualizarEstado;

namespace ValidarExcel.Negocio
{
    public class NValida
    {
        public List<CExcelID> validaEx;
        public MValida mValida;
        public CExcelID val;
        public NValida()
        {
            this.validaEx = new List<CExcelID>();
            this.mValida = new MValida();
        }
        public List<CExcelID> Obtenercarga()
        {
            List<CExcelID> validaciones = new List<CExcelID>();
            
            var _dtValidaciones = mValida.ObtenerCarga();
            if (_dtValidaciones.Rows.Count > 0)
            {
                foreach (DataRow row in _dtValidaciones.Rows)
                {
                    this.val = new CExcelID();
                    this.val.IDCarga = Convert.ToInt32(row["IDCarga"]);
                    this.val.IDCargaExcel = Convert.ToString(row["IDCargaExcel"]);
                    this.val.IDCliente = Convert.ToInt32(row["IDCliente"]);
                    this.val.DatosCarga = Convert.ToString(row["DatosCarga"]);
                    this.val.CodEstado = Convert.ToInt32(row["CodEstado"]);
                    this.val.CodError = Convert.ToInt32(row["CodError"]);
                    validaciones.Add(val);
                }
            }
            return validaciones;
        }
        public CExcelResp ValidarExcel(int validaExcelRequest, string dc, int? Estado)
        {
            var resultadoUp = mValida.ValidarExcel(validaExcelRequest,dc, Estado);
            CExcelResp cResultado = new CExcelResp();
            if (resultadoUp.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoUp.Rows)
                {
                    cResultado.IDCarga = Convert.ToString(row["IDCarga"]);
                    cResultado.NombreDestinatario = Convert.ToString(row["NombreDestinatario"]);
                    cResultado.ApellidoPaternoDestinatario = Convert.ToString(row["ApellidoPaternoDestinatario"]);
                    cResultado.ApellidoMaternoDestinatario = Convert.ToString(row["ApellidoMaternoDestinatario"]);
                    cResultado.CodProdOT = Convert.ToString(row["CodProdOT"]);
                    cResultado.TipoEntrega = Convert.ToString(row["TipoEntrega"]);
                    cResultado.EmailEntrega = Convert.ToString(row["EmailEntrega"]);
                    cResultado.CelularEntrega = Convert.ToString(row["CelularEntrega"]);
                    cResultado.ValorDeclaradoProducto = Convert.ToString(row["ValorDeclaradoProducto"]);
                    cResultado.TipoArticulo = Convert.ToString(row["TipoArticulo"]);
                    cResultado.GlsContenido = Convert.ToString(row["GlsContenido"]);
                    cResultado.GlsCobertura = Convert.ToString(row["GlsCobertura"]);
                    cResultado.GlsCalle = Convert.ToString(row["GlsCalle"]);
                    cResultado.GlsNumeracion = Convert.ToString(row["GlsNumeracion"]);
                    cResultado.GlsComplemento = Convert.ToString(row["GlsComplemento"]);
                    cResultado.LargoPza = Convert.ToString(row["LargoPza"]);
                    cResultado.AnchoPza = Convert.ToString(row["AnchoPza"]);
                    cResultado.AltoPza = Convert.ToString(row["AltoPza"]);
                    cResultado.PesoOT = Convert.ToString(row["PesoOT"]);
                }
            }
            return cResultado;
        }

        public async Task<ActualizarResponse> UpdateValidaciones(ActualizarRequest _actualizarRequest)
        {
            var resultadoUp = mValida.ActualizarValidaciones(_actualizarRequest);
            ActualizarResponse cResultado = new ActualizarResponse();
            if (resultadoUp.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoUp.Rows)
                {
                    cResultado.IDCarga = Convert.ToString(row["IDCarga"]);
                    cResultado.NombreDestinatario = Convert.ToString(row["NombreDestinatario"]);
                    cResultado.ApellidoPaternoDestinatario = Convert.ToString(row["ApellidoPaternoDestinatario"]);
                    cResultado.ApellidoMaternoDestinatario = Convert.ToString(row["ApellidoMaternoDestinatario"]);
                    cResultado.CodProdOT = Convert.ToString(row["CodProdOT"]);
                    cResultado.TipoEntrega = Convert.ToString(row["TipoEntrega"]);
                    cResultado.EmailEntrega = Convert.ToString(row["EmailEntrega"]);
                    cResultado.CelularEntrega = Convert.ToString(row["CelularEntrega"]);
                    cResultado.ValorDeclaradoProducto = Convert.ToString(row["ValorDeclaradoProducto"]);
                    cResultado.TipoArticulo = Convert.ToString(row["TipoArticulo"]);
                    cResultado.GlsContenido = Convert.ToString(row["GlsContenido"]);
                    cResultado.GlsCobertura = Convert.ToString(row["GlsCobertura"]);
                    cResultado.GlsCalle = Convert.ToString(row["GlsCalle"]);
                    cResultado.GlsNumeracion = Convert.ToString(row["GlsNumeracion"]);
                    cResultado.GlsComplemento = Convert.ToString(row["GlsComplemento"]);
                    cResultado.LargoPza = Convert.ToString(row["LargoPza"]);
                    cResultado.AnchoPza = Convert.ToString(row["AnchoPza"]);
                    cResultado.AltoPza = Convert.ToString(row["AltoPza"]);
                    cResultado.PesoOT = Convert.ToString(row["PesoOT"]);
                    cResultado.CotizadorNacional = Convert.ToString(row["CotizadorNacional"]);
                    cResultado.GlsCobSucursal = Convert.ToString(row["GlsCobSucursal"]);
                    cResultado.DireccionDestino = Convert.ToString(row["DireccionDestino"]);
                    cResultado.DireccionOrigen = Convert.ToString(row["DireccionOrigen"]);
                }
            }
            return cResultado;
        }
        public ActualizarEstado ActualizarEstado(ActualizarEstadoRequest _actualizarRequest)
        {
            var resultadoUp = mValida.ActualizarEstado(_actualizarRequest);
            ActualizarEstado cResultado = new ActualizarEstado();
            if (resultadoUp.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoUp.Rows)
                {
                    cResultado.Mensaje = Convert.ToString(row["MENSAJE"]);
                    cResultado.Resultado = Convert.ToBoolean(row["RESULTADO"]);
                }
            }
            return cResultado;
        }
        public EstructuraResponse CargarEstructura(int IDCarga,string IDCargaExcel, decimal idCarro, string StreetName, int StreetNumber, string Latitude, string Longitude, int AddressId, int OfficeCode, string Destino, string Complement)
        {
            var resultadoUp = mValida.CargarEstructura(IDCarga,IDCargaExcel, idCarro, StreetName, StreetNumber, Latitude, Longitude, AddressId, OfficeCode, Destino, Complement);
            EstructuraResponse cResultado = new EstructuraResponse();
            if (resultadoUp.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoUp.Rows)
                {
                    cResultado.Mensaje = Convert.ToString(row["MENSAJE"]);
                    cResultado.Resultado = Convert.ToBoolean(row["RESULTADO"]);
                }
            }
            return cResultado;
        }
        public EstructuraResponse finalizarEstado(string IDCargaExcel)
        {
            var resultadoUp = mValida.finalizarEstado(IDCargaExcel);
            EstructuraResponse cResultado = new EstructuraResponse();
            if (resultadoUp.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoUp.Rows)
                {
                    cResultado.Mensaje = Convert.ToString(row["MENSAJE"]);
                    cResultado.Resultado = Convert.ToBoolean(row["RESULTADO"]);
                }
            }
            return cResultado;
        }
    }
}
