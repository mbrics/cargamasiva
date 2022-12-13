using System;
using System.Collections.Generic;
using System.Text;

namespace ValidarExcel.Model.Sucursales
{
    public class SucursalResponse
    {
        public List<Office> offices { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public object errors { get; set; }
    }
    public class Office
    {
        public string regionName { get; set; }
        public string countyName { get; set; }
        public string officeName { get; set; }
        public int officeType { get; set; }
        public string streetName { get; set; }
        public int streetNumber { get; set; }
        public string complement { get; set; }
        public int addressId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int streetNameId { get; set; }
        public int ineCountyId { get; set; }
        public string managerName { get; set; }
        public string telephone { get; set; }
        public int officeCode { get; set; }
        public string regionCode { get; set; }
        public string eMail { get; set; }
    }
}
