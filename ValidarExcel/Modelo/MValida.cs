using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using ValidarExcel.Model;
using ValidarExcel.Model.ActualizarEstado;
using ValidarExcel.Model.ActualizarValidaExcel;

namespace ValidarExcel.Modelo
{
    public class MValida
    {
        private string connStrIncidencia = Environment.GetEnvironmentVariable("ConnectionValida").ToString();
        public DataTable ValidarExcel(int validarExcelRequest, string dc, int? Estado)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_siu_app_validaExcel", conn);
                cmd.Parameters.AddWithValue("@IDCarga", validarExcelRequest);
                cmd.Parameters.AddWithValue("@DC", dc);
                cmd.Parameters.AddWithValue("@ActualizarEstadoCarga", Estado);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tabla";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
        public DataTable ActualizarValidaciones(ActualizarRequest _actualizarRequest)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_u_app_modificarValidarExcel", conn);
                cmd.Parameters.AddWithValue("@IDCarga", _actualizarRequest.IDCarga);
                cmd.Parameters.AddWithValue("@direccionOrigen", _actualizarRequest.DireccionOrigen);
                cmd.Parameters.AddWithValue("@direccionDestino", _actualizarRequest.DireccionDestino);
                cmd.Parameters.AddWithValue("@sucursal", _actualizarRequest.Sucursal);
                cmd.Parameters.AddWithValue("@estadoCotNacional", _actualizarRequest.EstadoCotizador);
                cmd.Parameters.AddWithValue("@estadoDirOrigen", _actualizarRequest.EstadoDirOrigen);
                cmd.Parameters.AddWithValue("@estadoDirDestino", _actualizarRequest.EstadoDirDestino);
                cmd.Parameters.AddWithValue("@estadoSucursal", _actualizarRequest.EstadoSucursal);
                cmd.Parameters.AddWithValue("@CodOrigen", _actualizarRequest.CodOrigen);
                cmd.Parameters.AddWithValue("@CodDestino", _actualizarRequest.CodDestino);
                cmd.Parameters.AddWithValue("@TotalValor", _actualizarRequest.TotalValor);
                cmd.Parameters.AddWithValue("@TipoEntrega", _actualizarRequest.TipoEntrega);
                cmd.Parameters.AddWithValue("@estadoDirecciones", _actualizarRequest.EstadoDireccion);
                cmd.Parameters.AddWithValue("@GlsCalle", _actualizarRequest.GlsCalle);
                cmd.Parameters.AddWithValue("@GlsNumeracion", _actualizarRequest.GlsNumeracion);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tablaCXPUpdateValidaciones";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
        public DataTable ActualizarEstado(ActualizarEstadoRequest _actualizarRequest)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_u_app_actualizarEstado", conn);
                cmd.Parameters.AddWithValue("@IDCargaExcel", _actualizarRequest.IDCargaExcel);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tablaCXPActualizarEstado";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
        public DataTable CargarEstructura(int IDCarga, string IDCargaExcel, decimal idCarro, string StreetName, int StreetNumber, string Latitude, string Longitude, int AddressId, int OfficeCode, string Destino, string Complement)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_siu_app_cargaEstructura", conn);
                cmd.Parameters.AddWithValue("@IDCarga", IDCarga);
                cmd.Parameters.AddWithValue("@IDCargaExcel", IDCargaExcel);
                cmd.Parameters.AddWithValue("@IDCarro", Convert.ToInt32(idCarro));
                cmd.Parameters.AddWithValue("@StreetName", StreetName);
                cmd.Parameters.AddWithValue("@StreetNumber", StreetNumber.ToString());
                cmd.Parameters.AddWithValue("@Latitude", Latitude == "" ? 0 : Convert.ToDecimal(Latitude, culture));
                cmd.Parameters.AddWithValue("@Longitude", Longitude == "" ? 0 : Convert.ToDecimal(Longitude, culture));
                cmd.Parameters.AddWithValue("@AddressId", AddressId);
                cmd.Parameters.AddWithValue("@OfficeCode", OfficeCode);
                cmd.Parameters.AddWithValue("@DestinoRemitente", Destino);
                cmd.Parameters.AddWithValue("@Complement", Complement);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tablaCXPInsertCargaEstructura";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
        public DataTable finalizarEstado(string IDCargaExcel)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_u_app_finalizarEstadoCarga", conn);
                cmd.Parameters.AddWithValue("@IDCargaExcel", IDCargaExcel);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tablaCXPFinalizarCargaEstado";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
        public DataTable ObtenerCarga()
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable();
                conn = new SqlConnection(connStrIncidencia);
                conn.Open();

                cmd = new SqlCommand("dbo.pr_s_app_obtenerCarga", conn);
                cmd.Parameters.AddWithValue("@estado", 0);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dt.TableName = "tablaWuUpdateIncidencia";
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                conn = null;
                dr = null;
                cmd = null;
            }
        }
    }
}
