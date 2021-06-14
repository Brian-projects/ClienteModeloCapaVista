using ClienteView.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ClienteView.Services
{
    public class TipoClienteServices : BaseService
    {
        public TipoClienteServices() 
        {
            Http = new HttpClient();
            Configuration = ConfigurationManager.AppSettings;
            BaseUrl = Configuration.Get("BaseUrl");
        }

        public async Task<ICollection<TipoClienteModel>> GetTipoClientes() 
        {
            HttpResponseMessage response;
            try
            {
                response = await Http.GetAsync($"{BaseUrl}/api/tipocliente");
                response.EnsureSuccessStatusCode();
                ICollection<TipoClienteModel> responseBody = JsonConvert.DeserializeObject<ICollection<TipoClienteModel>>(await response.Content.ReadAsStringAsync());

                return responseBody;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}