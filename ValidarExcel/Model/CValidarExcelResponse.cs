using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model
{
    public class CValidarExcelResponse
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public List<CExcelResp> ValidaExcelResp { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public int statusCode { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public string statusDescription { get; set; }

        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public string errors { get; set; }
        public CValidarExcelResponse()
        {

        }
        public CValidarExcelResponse(CValidarExcelResponse model) : this()
        {
            ValidaExcelResp = model.ValidaExcelResp;
            this.statusCode = this.statusCode;
            this.statusDescription = this.statusDescription;
            this.errors = this.errors;
        }
    }
}
