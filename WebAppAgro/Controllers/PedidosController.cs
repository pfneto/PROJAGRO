using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjAgroDDD.Venda.Domain;
using Newtonsoft.Json;

namespace WebAppAgro.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Ped
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Pedidos()
        {
            ViewBag.Message = "Lista de Pedidos";

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("http://webapiagro.azurewebsites.net/api/Pedidos");

            var PedidoList = JsonConvert.DeserializeObject<IEnumerable<Pedido>>(json);

            // var model 

            return View(PedidoList);
        }
    }
}