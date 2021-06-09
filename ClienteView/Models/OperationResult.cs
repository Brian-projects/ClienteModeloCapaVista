using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteView.Models
{
    public class OperationResult<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}