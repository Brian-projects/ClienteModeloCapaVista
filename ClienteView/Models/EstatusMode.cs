using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteView.Models
{
    public class EstatusModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool State { get; set; }
    }
}