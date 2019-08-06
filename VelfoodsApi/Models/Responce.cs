using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class Responce
    {

        public string message { get; set; }
        public int code { get; set; }
        public object Data { get; set; }
    }
}