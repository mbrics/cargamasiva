using System;
using System.Collections.Generic;
using System.Text;

namespace ValidarExcel.Model.Direcciones
{
    public class DireccionesRequest
    {
        public string streetName { get; set; }
        public string countyName { get; set; }
        public int number { get; set; }
    }
}
