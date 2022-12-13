using System;
using System.Collections.Generic;
using System.Text;

namespace ValidarExcel.Model.Direcciones
{
    public class DireccionesResponse
    {
        public Direcciones Data { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string errors { get; set; }
        public DireccionesResponse()
        {

        }
        public DireccionesResponse(DireccionesResponse model) : this()
        {
            Data.addressId = model.Data.addressId;
            Data.latitude = model.Data.latitude;
            Data.longitude = model.Data.longitude;
            this.statusCode = this.statusCode;
            this.statusDescription = this.statusDescription;
            this.errors = this.errors;
        }
    }
}