using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.Georeference
{
    public class Cobertura
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public string countyCode { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string countyName { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public string regionCode { get; set; }
        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public int ineCountyCode { get; set; }
        [DataMember(Order = 5)]
        [JsonProperty(Order = 5)]
        public int queryMode { get; set; }
        [DataMember(Order = 6)]
        [JsonProperty(Order = 6)]
        public string coverageName { get; set; }
    }
}
