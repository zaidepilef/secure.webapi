using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSecure.Model
{
    public class Cliente
    {
        public string nombre_empresa { get; set; }
        public string id_empresa { get; set; }
        public string url_empresa { get; set; }
        public string api_key { get; set; }
  
    }
}