﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidarExcel.Model.GenerarCarro
{
    public class GenerarCarroResponse
    {
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public GenerarCarro CartAddResp { get; set; }
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public int statusCode { get; set; }
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public string statusDescription { get; set; }

        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public string errors { get; set; }

        public GenerarCarroResponse()
        {

        }
    }
}
