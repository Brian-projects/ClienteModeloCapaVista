using ClienteView.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClienteView.Services
{
    public class ClienteService : BaseService
    {
        public ClienteService()
        {
            Http = new HttpClient();
            Configuration = ConfigurationManager.AppSettings;
            BaseUrl = Configuration.Get("BaseUrl");
        }

        public async Task<OperationResult<List<ClienteModel>>> Get()
        {
            HttpResponseMessage response;
            try
            {
                response = await Http.GetAsync($"{BaseUrl}/Api/Cliente");
                response.EnsureSuccessStatusCode();
                List<ClienteModel> responseBody = JsonConvert.DeserializeObject<List<ClienteModel>>(await response.Content.ReadAsStringAsync());
                return new OperationResult<List<ClienteModel>>()
                {
                    Status = (int)HttpStatusCode.OK,
                    Message = "Success",
                    Data = responseBody
                };
            }
            catch (Exception e)
            {
                return new OperationResult<List<ClienteModel>>()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Message = e.Message,
                    Data = null
                };
            }
        }

        public async Task<OperationResult<ClienteModelExtended>> GetById(int Id) 
        {

            HttpResponseMessage response;

            try 
            {
                response = await Http.GetAsync($"{BaseUrl}/Api/Cliente/{Id}");
                response.EnsureSuccessStatusCode();
                OperationResult<ClienteModelExtended> responseBody = JsonConvert.DeserializeObject<OperationResult<ClienteModelExtended>>(await response.Content.ReadAsStringAsync());
                return new OperationResult<ClienteModelExtended>()
                {
                    Status = responseBody.Status,
                    Message = responseBody.Message,
                    Data = responseBody.Data,
                };
            } catch (Exception e) 
            {
                return new OperationResult<ClienteModelExtended>()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Message = e.Message,
                    Data = null
                };
            }
        }

        public async Task<OperationResult<ClienteModel>> CreateCliente(ClienteModel cliente) 
        {
            HttpResponseMessage response;
            try
            {
                var jsontext = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(jsontext, Encoding.UTF8, "application/json");

                response = await Http.PostAsync($"{BaseUrl}/api/cliente",content);
                response.EnsureSuccessStatusCode();
                OperationResult<ClienteModel> responseBody = JsonConvert.DeserializeObject<OperationResult<ClienteModel>>(await response.Content.ReadAsStringAsync());
                return responseBody;
            }
            catch (Exception e)
            {
                return new OperationResult<ClienteModel>()
                {
                    Data = null,
                    Status = (int)HttpStatusCode.BadRequest,
                    Message = e.Message
                };
                throw;
            }
        }
    }
}