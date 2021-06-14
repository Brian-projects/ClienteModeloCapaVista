using ClienteView.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClienteView.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService clienteService;
        private readonly TipoClienteServices tipoClienteServices;
        private readonly EstatusServices estatusServices;
        public ClienteController() 
        {
            clienteService = new ClienteService();
            tipoClienteServices = new TipoClienteServices();
            estatusServices = new EstatusServices();
        }
        // GET: Cliente
        public async  Task<ActionResult> ListadoClientes()
        {
            var model = await clienteService.Get();
            return View(model);
        }

        public async Task<ActionResult> DetalleCliente(int Id) 
        {
            var result = await clienteService.GetById(Id);
            
            return View(result.Data);
        }

        public async Task<ActionResult> CrearCliente() 
        {
            ViewBag.TipoClientes = await tipoClienteServices.GetTipoClientes();
            ViewBag.Estatus = await estatusServices.GetEstatus();
            return View();
        }
    }
}