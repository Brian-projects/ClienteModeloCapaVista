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
    public class EstatusServices : BaseService
    {
        public EstatusServices() 
        {
            Http = new HttpClient();
            Configuration = ConfigurationManager.AppSettings;
            BaseUrl = Configuration.Get("BaseUrl");
        }

        public async Task<ICollection<EstatusModel>> GetEstatus() 
        {
            HttpResponseMessage response;

            try
            {
                response = await Http.GetAsync($"{BaseUrl}/api/estatus");
                response.EnsureSuccessStatusCode();
                ICollection<EstatusModel> responseBody = JsonConvert.DeserializeObject<ICollection<EstatusModel>>(await response.Content.ReadAsStringAsync());
                return responseBody;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}