using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model
{
    public class CExcelID
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public int IDCarga { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string IDCargaExcel { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public int IDCliente { get; set; }
        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public string DatosCarga { get; set; }
        [DataMember(Order = 5)]
        [JsonProperty(Order = 5)]
        public int CodEstado { get; set; }
        [DataMember(Order = 6)]
        [JsonProperty(Order = 6)]
        public int CodError { get; set; }

    }
}
