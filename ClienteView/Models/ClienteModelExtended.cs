using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClienteView.Models
{
    public class ClienteModelExtended 
    {
        public ClienteModel cliente { get; set; }
        public string TipoClienteDescripcion { get; set; }
        public string EstatusDescripcion { get; set; }
    }
}