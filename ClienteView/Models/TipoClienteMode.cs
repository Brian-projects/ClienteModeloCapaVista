﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteView.Models
{
    public class TipoClienteMode
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }
    }
}