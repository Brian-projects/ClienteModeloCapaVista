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
        public ClienteController() 
        {
            clienteService = new ClienteService();
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
    }
}