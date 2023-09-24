using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KmnlkBarcodeApi.Models
{
    public class ResponseModel
    {
        public string startTime;
        public string endTime;
        public HttpStatusCode code;
        public string msg;
        public object data;
        public ResponseModel(object data, string msg, HttpStatusCode code, string startTime, string endTime)
        {
            this.code = code;
            this.data = data;
            this.msg = msg;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}