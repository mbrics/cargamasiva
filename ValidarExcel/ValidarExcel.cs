using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ValidarExcel.Servicio;
using ValidarExcel.Model;
using System.Collections.Generic;
using ValidarExcel.Negocio;
using System.Linq;
using ValidarExcel.Model.CotizadorNacional;
using ValidarExcel.Model.ActualizarValidaExcel;
using ValidarExcel.Model.CargarEstructura;
using ValidarExcel.Model.GenerarCarro;
using System.Globalization;
using ValidarExcel.Model.ActualizarEstado;
using System.Configuration;
using ValidarExcel.Model.Direcciones;

namespace ValidarExcel
{
    public static class ValidarExcel
    {
        [FunctionName("ValidaExcel")]
        public static async Task Run([TimerTrigger("%tiempoEjecucion%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            NValida nValida = new NValida();
            try
            {
                List<CExcelID> cargas = nValida.Obtenercarga();
                var cargasFiltradas = cargas.Select(x => x.IDCargaExcel).Distinct().ToList();
                List<CExcelID> cargasFil = new List<CExcelID>();
                ActualizarRequest _actualizarRequest = new ActualizarRequest();
                EstructuraResponse estadoCarga = new EstructuraResponse();
                CultureInfo culture = new CultureInfo("en-US");
                string urlSucursales = Convert.ToString(Environment.GetEnvironmentVariable("UrlSucursales", EnvironmentVariableTarget.Process));
                string urlCobertura = Convert.ToString(Environment.GetEnvironmentVariable("UrlCoberturas", EnvironmentVariableTarget.Process));
                string urlCotizador = Convert.ToString(Environment.GetEnvironmentVariable("UrlCotizador", EnvironmentVariableTarget.Process));
                string urlCarro = Convert.ToString(Environment.GetEnvironmentVariable("UrlCarro", EnvironmentVariableTarget.Process));
                string urlDirecciones = Convert.ToString(Environment.GetEnvironmentVariable("UrlDirecciones", EnvironmentVariableTarget.Process));
                if (cargasFiltradas.Count > 0)
                {
                    SValida sValida = new SValida();
                    var _coberturas = sValida.GetCobertura(urlCobertura);
                    var _sucursales = sValida.GetSucursales(99, 0, urlSucursales);
                    List<CExcelResp> validaciones = new List<CExcelResp>();
                    List<Boolean> comprobarValidacio = new List<Boolean>();
                    List<Direcciones> _listaDirecciones = new List<Direcciones>();
                    List<string> _idCargaExcel = new List<string>();
                    var _idCarga = "";
                    foreach (var item in cargasFiltradas)
                    {

                        try
                        { 
                            var _registrosFiltrados = cargas.Where(x => x.IDCargaExcel.Equals(item)).ToList();
                            var _cont = 1;
                            foreach (var registro in _registrosFiltrados)
                            {
                                if (registro.CodEstado == 0 || registro.CodEstado == 3)
                                {
                                    ValNacionalRequest _valNacionalRequest = new ValNacionalRequest();
                                    DireccionesRequest _direccionesRequest = new DireccionesRequest();
                                    CExcelResp _validacionResp = new CExcelResp();
                                    var _datosCarga = JsonConvert.DeserializeObject<CExcelResp>(registro.DatosCarga);

                                    _idCarga = registro.IDCargaExcel;
                                    if (_cont==_registrosFiltrados.Count())
                                        _validacionResp = sValida.ValidaExcel(registro.IDCarga, registro.DatosCarga, 1);
                                    else
                                        _validacionResp = sValida.ValidaExcel(registro.IDCarga, registro.DatosCarga, 0);

                                    var _countyCodeOrig = _coberturas.coverageAreas.Where(x => x.countyName == _datosCarga.Origen.ToUpper()).Select(x => x.countyCode).ToList();
                                    var _countyCodeDest = _coberturas.coverageAreas.Where(x => x.coverageName == _datosCarga.Destino.ToUpper()).Select(x => x.countyCode).ToList();
                                    var _validaCobertura = _sucursales.offices.Where(x => x.officeName == _datosCarga.GlsCobertura.ToUpper() && x.countyName == _datosCarga.Destino.ToUpper()).ToList();
                                    var _tipoEntrega = _datosCarga.TipoEntrega.ToUpper();
                                    if (_tipoEntrega == "DOMICILIO")
                                    {
                                        _direccionesRequest.streetName = _datosCarga.GlsCalle;
                                        _direccionesRequest.number = _datosCarga.GlsNumeracion == "" ? 0 : Convert.ToInt32(_datosCarga.GlsNumeracion);
                                        _direccionesRequest.countyName = _datosCarga.Destino;
                                        var _direcciones = sValida.PostDirecciones(_direccionesRequest, urlDirecciones);
                                        _listaDirecciones.Add(_direcciones.Data);
                                        _actualizarRequest.EstadoDireccion = _direcciones.statusCode == 0 ? 1 : 0;
                                        _actualizarRequest.GlsCalle = _datosCarga.GlsCalle;
                                        _actualizarRequest.GlsNumeracion = _datosCarga.GlsNumeracion;
                                    }

                                    var _codTipoDocumento = sValida.TipoDocumento(_datosCarga.CodProdOT.Trim());
                                    _valNacionalRequest.CIUDAD_DESTINO = _countyCodeDest.Count == 0 ? "" : _countyCodeDest[0].ToString().ToUpper();
                                    _valNacionalRequest.CIUDAD_ORIGEN = _countyCodeOrig.Count == 0 ? "" : _countyCodeOrig[0].ToString().ToUpper();
                                    _valNacionalRequest.COD_PRODUCTO = _codTipoDocumento;
                                    _valNacionalRequest.PESO = Convert.ToDecimal(_datosCarga.PesoOT, culture);
                                    _valNacionalRequest.ALTO = Convert.ToInt32(Convert.ToDecimal(_datosCarga.AltoPza, culture));
                                    _valNacionalRequest.ANCHO = Convert.ToInt32(Convert.ToDecimal(_datosCarga.AnchoPza, culture));
                                    _valNacionalRequest.LARGO = Convert.ToInt32(Convert.ToDecimal(_datosCarga.LargoPza, culture));
                                    _valNacionalRequest.VALOR_DECLARADO = _codTipoDocumento != 3 ? 0 : Convert.ToDecimal(_datosCarga.ValorDeclaradoProducto);
                                    var cotizadorResponse = sValida.CotizadorNacional(_valNacionalRequest, urlCotizador);
                                    var valorTotal = cotizadorResponse.ListCotiNacional.Where(b => b.NOM_SERVICIO == _datosCarga.GlsContenido).Select(a => a.VALOR).ToList();
                                    var existeServicio = cotizadorResponse.ListCotiNacional.Where(x => x.NOM_SERVICIO == _datosCarga.GlsContenido).ToList();
                                    if (existeServicio.Count == 0)
                                    {
                                        _actualizarRequest.EstadoCotizador = 3;
                                    }
                                    else
                                    {
                                        if (cotizadorResponse.ListCotiNacional.Count > 0)
                                            if (cotizadorResponse.ListCotiNacional[0].NOM_SERVICIO == "SIN SERVICIO")
                                                _actualizarRequest.EstadoCotizador = 2;
                                            else
                                                _actualizarRequest.EstadoCotizador = 1;
                                        else
                                            _actualizarRequest.EstadoCotizador = cotizadorResponse.ListCotiNacional.Count > 0 ? 1 : 0;
                                    }

                                    _actualizarRequest.IDCarga = registro.IDCarga;
                                    _actualizarRequest.DireccionOrigen = _datosCarga.Origen;
                                    _actualizarRequest.DireccionDestino = _datosCarga.Destino;
                                    _actualizarRequest.Sucursal = _datosCarga.GlsCobertura;
                                    _actualizarRequest.EstadoDirOrigen = _countyCodeOrig.Count > 0 ? 1 : 0;
                                    _actualizarRequest.EstadoDirDestino = _countyCodeDest.Count > 0 ? 1 : 0;
                                    _actualizarRequest.EstadoSucursal = _validaCobertura.Count > 0 ? 1 : 0;
                                    _actualizarRequest.TipoEntrega = _datosCarga.TipoEntrega;
                                    _actualizarRequest.CodOrigen = _countyCodeOrig.Count > 0 ? _countyCodeOrig[0] : "";
                                    _actualizarRequest.CodDestino = _countyCodeDest.Count > 0 ? _countyCodeDest[0] : "";
                                    _actualizarRequest.TotalValor = 0;

                                    if (valorTotal.Count > 0)
                                        _actualizarRequest.TotalValor = valorTotal[0].Value;


                                    var estadoActualizacion = await sValida.UpdateValidaciones(_actualizarRequest);

                                    if (estadoActualizacion.DireccionOrigen == "OK" && estadoActualizacion.DireccionDestino == "OK" && estadoActualizacion.GlsCobSucursal == "OK" && estadoActualizacion.AltoPza == "OK" && estadoActualizacion.AnchoPza == "OK" && estadoActualizacion.LargoPza == "OK" && estadoActualizacion.PesoOT == "OK" && estadoActualizacion.NombreDestinatario == "OK" && estadoActualizacion.ApellidoPaternoDestinatario == "OK" && estadoActualizacion.ApellidoMaternoDestinatario == "OK" && estadoActualizacion.CodProdOT == "OK" && estadoActualizacion.TipoEntrega == "OK" && estadoActualizacion.EmailEntrega == "OK" && estadoActualizacion.CelularEntrega == "OK" && estadoActualizacion.ValorDeclaradoProducto == "OK" && estadoActualizacion.TipoArticulo == "OK" && estadoActualizacion.GlsContenido == "OK" && estadoActualizacion.GlsCobertura == "OK" && estadoActualizacion.GlsCalle == "OK" && estadoActualizacion.GlsNumeracion == "OK" && estadoActualizacion.GlsCalle == "OK" && estadoActualizacion.GlsNumeracion == "OK" && estadoActualizacion.GlsComplemento == "OK" && estadoActualizacion.GlsNumeracion == "OK")
                                        comprobarValidacio.Add(false);
                                    else
                                        comprobarValidacio.Add(true);

                                    if (comprobarValidacio.Contains(true))
                                    {
                                        _idCargaExcel.Add(registro.IDCargaExcel);
                                    }
                                }
                                _cont++;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                    if (comprobarValidacio.Contains(true))
                    {
                        ActualizarEstadoRequest _actualizarEstadoRequest = new ActualizarEstadoRequest();
                        var listaIDCarga = _idCargaExcel.Distinct();
                        foreach (var idCargaExcel in listaIDCarga)
                        {
                            _actualizarEstadoRequest.IDCargaExcel = idCargaExcel;
                            var actualizarEstado = sValida.ActualizarEstado(_actualizarEstadoRequest);
                        }
                        estadoCarga.Resultado = false;
                        estadoCarga.Mensaje = "Error en carga";
                        log.LogInformation($"Estado Carga => [{estadoCarga}] ");
                    }
                    else
                    {
                        GenerarCarroRequest generarCarroRequest = new GenerarCarroRequest();
                        generarCarroRequest.TotalValorCarro = 0;
                        generarCarroRequest.CantidadItem = cargas.Count();
                        generarCarroRequest.TipoDescuento = 0;
                        generarCarroRequest.ValorDescuento = 0;
                        generarCarroRequest.CodCupon = "";
                        generarCarroRequest.IDCliente = cargas[0].IDCliente;
                        generarCarroRequest.IDMedioPago = 0;
                        generarCarroRequest.NumeroDocumentoTributario = 0;
                        generarCarroRequest.DocId = "";
                        generarCarroRequest.ValorTotalCobrado = 0;
                        generarCarroRequest.TipoBilletera = "";
                        generarCarroRequest.CodAutorizacionPago = "";
                        generarCarroRequest.NombreBilletera = "";
                        generarCarroRequest.NumBilletera = "";

                        var idCarro = sValida.GenerarCarro(generarCarroRequest, urlCarro).CartAddResp.Carro;
                        for (int i = 0; i < cargas.Count; i++)
                        {
                            if (cargas[i].CodEstado == 0 || cargas[i].CodEstado == 3)
                            {
                                var _carga = JsonConvert.DeserializeObject<CExcelResp>(cargas[i].DatosCarga);
                                var _validaCobertura = _sucursales.offices.Where(x => x.officeName == _carga.GlsCobertura.ToUpper()).ToList();
                                var _streetName = _validaCobertura.Count == 0 ? "" : _validaCobertura[0].streetName;
                                var _streetNumber = _validaCobertura.Count == 0 ? 0 : _validaCobertura[0].streetNumber;
                                var _latitude = _validaCobertura.Count == 0 ? "" : _validaCobertura[0].latitude;
                                var _longitude = _validaCobertura.Count == 0 ? "" : _validaCobertura[0].longitude;
                                var _addressId = _validaCobertura.Count == 0 ? 0 : _validaCobertura[0].addressId;
                                var _officeCode = _validaCobertura.Count == 0 ? 0 : _validaCobertura[0].officeCode;
                                var _complement = _validaCobertura.Count == 0 ? "" : _validaCobertura[0].complement;
                                var _tipoEntrega = _carga.TipoEntrega.ToUpper();
                                if (_tipoEntrega.ToUpper() == "DOMICILIO")
                                {
                                    if (_latitude == "" && _longitude == "")
                                    {
                                        _addressId = _listaDirecciones.Count == 0 ? 0 : _listaDirecciones[0].addressId;
                                        _latitude = _listaDirecciones.Count == 0 ? "" : _listaDirecciones[0].latitude;
                                        _longitude = _listaDirecciones.Count == 0 ? "" : _listaDirecciones[0].longitude;
                                    }
                                }
                                estadoCarga = sValida.CargarEstructura(cargas[i].IDCarga, cargas[i].IDCargaExcel, idCarro, _streetName, _streetNumber, _latitude, _longitude, _addressId, _officeCode, _carga.Destino, _complement);
                            }
                        }
                        log.LogInformation($"Estado Carga => [{estadoCarga}] ");
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogInformation($"Error Exception => {ex.Message}");
            }
        }
    }
}
