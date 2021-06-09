using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ClienteView.Services
{
    public class BaseService
    {
        protected NameValueCollection Configuration;
        protected string BaseUrl = null;
        protected HttpClient Http = null;
    }
}