using ClienteView.Models;
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
        public ActionResult ListadoClientes()
        {  
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListarClientes() 
        {
            var model = await clienteService.Get();
            return Json(model.Data, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public async Task<ActionResult> CrearCliente(ClienteModel cliente)
        {
            var result = await clienteService.CreateCliente(cliente);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ModificarCliente(int Id) 
        {
            var model = await clienteService.GetById(Id);
            ViewBag.TipoClientes = await tipoClienteServices.GetTipoClientes();
            ViewBag.Estatus = await estatusServices.GetEstatus();
            return View(model.Data);
        } 
     }
}