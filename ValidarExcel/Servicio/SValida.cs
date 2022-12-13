using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ValidarExcel.Model;
using ValidarExcel.Model.ActualizarEstado;
using ValidarExcel.Model.ActualizarValidaExcel;
using ValidarExcel.Model.CargarEstructura;
using ValidarExcel.Model.CotizadorNacional;
using ValidarExcel.Model.Direcciones;
using ValidarExcel.Model.GenerarCarro;
using ValidarExcel.Model.Georeference;
using ValidarExcel.Model.Sucursales;
using ValidarExcel.Negocio;

namespace ValidarExcel.Servicio
{
    public class SValida
    {
        public NValida nValida;
        public SValida()
        {
            this.nValida = new NValida();
        }
        public CExcelResp ValidaExcel(int validarExcelRequest, string dc, int? Estado)
        {
            try
            {
                var resultServ = nValida.ValidarExcel(validarExcelRequest, dc, Estado);
                return resultServ;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<ActualizarResponse> UpdateValidaciones(ActualizarRequest _actualizarRequest)
        {
            try
            {
                var resultServ = await nValida.UpdateValidaciones(_actualizarRequest);
                return resultServ;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActualizarEstado ActualizarEstado(ActualizarEstadoRequest _actualizarRequest)
        {
            try
            {
                var resultServ =  nValida.ActualizarEstado(_actualizarRequest);
                return resultServ;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EstructuraResponse CargarEstructura(int IDCarga,string IDCargaExcel,decimal idCarro,string StreetName,int StreetNumber,string Latitude, string Longitude, int AddressId, int OfficeCode, string Destino, string Complement)
        {
            try
            {
                var resultServ = nValida.CargarEstructura(IDCarga,IDCargaExcel,idCarro, StreetName, StreetNumber, Latitude, Longitude, AddressId, OfficeCode,Destino, Complement);
                return resultServ;
            }
            catch (Exception ex)
            {
                EstructuraResponse estructuraResponse = new EstructuraResponse();
                estructuraResponse.Resultado = false;
                estructuraResponse.Mensaje = "Internal Error";
                return estructuraResponse;
            }
        }
        public EstructuraResponse finalizarEstado(string IDCargaExcel)
        {
            try
            {
                var resultServ = nValida.finalizarEstado(IDCargaExcel);
                return resultServ;
            }
            catch (Exception)
            {
                EstructuraResponse estructuraResponse = new EstructuraResponse();
                estructuraResponse.Resultado = false;
                estructuraResponse.Mensaje = "Internal Error";
                return estructuraResponse;
            }
        }
        public CoberturaResponse GetCobertura(string urlCoberturas)
        {
            CoberturaResponse response = new CoberturaResponse();
            List<Cobertura> listCoberturas = new List<Cobertura>();

            HttpClient client = new HttpClient();
            urlCoberturas = $"{urlCoberturas}";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string _ocp = Convert.ToString(Environment.GetEnvironmentVariable("KeyCoberturas", EnvironmentVariableTarget.Process));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocp);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("GET"),
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            var res = client.GetAsync(urlCoberturas).Result;
            var responseBody = res.Content.ReadAsStringAsync();
            var restored = JsonConvert.DeserializeObject<CoberturaResponse>(responseBody.Result);
            if (restored.statusCode != 0)
            {
                response.coverageAreas = listCoberturas;
                response.statusCode = restored.statusCode;
                response.statusDescription = restored.statusDescription;
                response.errors = restored.errors;
                return response;
            }
            else
            {
                for (int i = 0; i < restored.coverageAreas.Count; i++)
                {
                    Cobertura respuesta = new Cobertura
                    {
                        countyCode = restored.coverageAreas[i].countyCode,
                        countyName = restored.coverageAreas[i].countyName,
                        regionCode = restored.coverageAreas[i].regionCode,
                        ineCountyCode = restored.coverageAreas[i].ineCountyCode,
                        queryMode = restored.coverageAreas[i].queryMode,
                        coverageName = restored.coverageAreas[i].coverageName
                    };

                    listCoberturas.Add(respuesta);
                }
                response.coverageAreas = listCoberturas;
                response.statusCode = restored.statusCode;
                response.statusDescription = restored.statusDescription;
                response.errors = restored.errors;
                return response;
            }
        }
        public SucursalResponse GetSucursales(int regionCode, int type, string url)
        {
            SucursalResponse response = new SucursalResponse();
            List<Office> listSucursal = new List<Office>();
            HttpClient client = new HttpClient();
            url = $"{url}?regionCode={regionCode}&type={type}";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string _ocp = Convert.ToString(Environment.GetEnvironmentVariable("KeySucursales", EnvironmentVariableTarget.Process));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocp);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("GET"),
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            var res = client.GetAsync(url).Result;
            var responseBody = res.Content.ReadAsStringAsync();
            var restored = JsonConvert.DeserializeObject<SucursalResponse>(responseBody.Result);
            if (restored.statusCode != 0)
            {
                response.offices = listSucursal;
                response.statusCode = restored.statusCode;
                response.statusDescription = restored.statusDescription;
                response.errors = restored.errors;
                return response;
            }
            else
            {
                for (int i = 0; i < restored.offices.Count; i++)
                {
                    Office respuesta = new Office
                    {
                        regionName = restored.offices[i].regionName,
                        regionCode = restored.offices[i].regionCode,
                        officeCode = restored.offices[i].officeCode,
                        officeName = restored.offices[i].officeName,
                        streetName = restored.offices[i].streetName,
                        streetNumber = restored.offices[i].streetNumber,
                        complement = restored.offices[i].complement,
                        addressId = restored.offices[i].addressId,
                        latitude = restored.offices[i].latitude,
                        longitude = restored.offices[i].longitude,
                        countyName = restored.offices[i].countyName
                    };

                    listSucursal.Add(respuesta);
                }
                response.offices = listSucursal;
                response.statusCode = restored.statusCode;
                response.statusDescription = restored.statusDescription;
                response.errors = restored.errors;

            }
            return response;
        }
        public DireccionesResponse PostDirecciones(DireccionesRequest direccionesRequest,string urlDirecciones)
        {
            HttpClient clientServ = new HttpClient();
            urlDirecciones = $"{urlDirecciones}";
            string _ocp = Convert.ToString(Environment.GetEnvironmentVariable("KeyDirecciones", EnvironmentVariableTarget.Process));
            clientServ.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocp);
            clientServ.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = new HttpMethod("POST");
            string sr_ = JsonConvert.SerializeObject(direccionesRequest);
            request.Content = new StringContent(sr_, Encoding.UTF8, "application/json");

            var res = clientServ.PostAsync(urlDirecciones, request.Content).Result;
            var responseBody = res.Content.ReadAsStringAsync();
            var resultServ = JsonConvert.DeserializeObject<DireccionesResponse>(responseBody.Result.ToString());

            return resultServ;
        }
        public CotiNacionalResponse CotizadorNacional(ValNacionalRequest valNacionalRequest, string urlCotizador)
        {
            HttpClient clientServ = new HttpClient();
            urlCotizador = $"{urlCotizador}?cIUDAD_ORIGEN={valNacionalRequest.CIUDAD_ORIGEN}&cIUDAD_DESTINO={valNacionalRequest.CIUDAD_DESTINO}&cOD_PRODUCTO={valNacionalRequest.COD_PRODUCTO}&pESO={valNacionalRequest.PESO:0.###}&Largo={valNacionalRequest.LARGO}&ancho={valNacionalRequest.ANCHO}&alto={valNacionalRequest.ALTO}&valor_declarado={valNacionalRequest.VALOR_DECLARADO}";
            var urlFormat = urlCotizador.Replace(",",".");
            string _ocp = Convert.ToString(Environment.GetEnvironmentVariable("KeyCotizador", EnvironmentVariableTarget.Process));
            clientServ.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocp);
            clientServ.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonServ = JsonConvert.SerializeObject(valNacionalRequest);
            var dataServ = new StringContent(jsonServ, Encoding.UTF8, "application/json");
            var responseServ = clientServ.GetAsync(urlFormat).Result;
            var resultServ = JsonConvert.DeserializeObject<CotiNacionalResponse>(responseServ.Content.ReadAsStringAsync().Result);

            return resultServ;
        }
        public GenerarCarroResponse GenerarCarro(GenerarCarroRequest generarCarroRequest, string UrlCarro)
        {
            HttpClient clientServ = new HttpClient();
            UrlCarro = $"{UrlCarro}";
            string _ocp = Convert.ToString(Environment.GetEnvironmentVariable("KeyCarro", EnvironmentVariableTarget.Process));
            clientServ.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocp);
            clientServ.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = new HttpMethod("POST");
            string sr_ = JsonConvert.SerializeObject(generarCarroRequest);
            request.Content = new StringContent(sr_, Encoding.UTF8, "application/json");

            var res = clientServ.PostAsync(UrlCarro, request.Content).Result;
            var responseBody = res.Content.ReadAsStringAsync();
            var resultServ = JsonConvert.DeserializeObject<GenerarCarroResponse>(responseBody.Result.ToString());

            return resultServ;
        }
        public int TipoDocumento(string CodProdOT)
        {
            var _codTipoDocumento = 0;
            var _tipoProducto = CodProdOT.ToUpper().Trim();
            if (_tipoProducto == "DOCUMENTO")
                _codTipoDocumento = 1;
            else if (_tipoProducto == "ENCOMIENDA")
                _codTipoDocumento = 3;
            else
                _codTipoDocumento = 2;
            return _codTipoDocumento;
        }
        public bool comprobarValidaciones(ActualizarResponse _validacionResp)
        {
            if (_validacionResp.DireccionOrigen == "OK" && _validacionResp.DireccionDestino == "OK" && _validacionResp.NombreDestinatario == "OK" && _validacionResp.ApellidoPaternoDestinatario == "OK" && _validacionResp.ApellidoMaternoDestinatario == "OK" && _validacionResp.CodProdOT == "OK" && _validacionResp.TipoEntrega == "OK" && _validacionResp.EmailEntrega == "OK" && _validacionResp.CelularEntrega == "OK" && _validacionResp.ValorDeclaradoProducto == "OK" && _validacionResp.TipoArticulo == "OK" && _validacionResp.GlsContenido == "OK" && _validacionResp.GlsCobertura == "OK" && _validacionResp.GlsCalle == "OK" && _validacionResp.GlsNumeracion == "OK" && _validacionResp.GlsComplemento == "OK" && _validacionResp.LargoPza == "OK" && _validacionResp.AnchoPza == "OK" && _validacionResp.AltoPza == "OK" && _validacionResp.PesoOT == "OK")
                return true;
            else
                return false;
        }
    }
}
