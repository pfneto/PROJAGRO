using Newtonsoft.Json;
using ProjAgroDDD.Produto.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebAppAgro.Controllers
{
   // [System.Web.Http.Authorize]
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }
     
        public async Task<ActionResult> ConsultaProdutos()
        {
            ViewBag.Message = "Consulta de Produtos";

            var httpClient = new HttpClient();

            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name



            try
            {
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {ticket.Name}");
            }
            catch
            {
                return RedirectToAction("AcessoNegado", "Home");
            }
             //Decrypt it           
                       
           
            var json = await httpClient.GetStringAsync("http://webapiagro.azurewebsites.net/api/Produtos");

            var ProdutoList = JsonConvert.DeserializeObject<IEnumerable<Produto>>(json);

            // var model 

            return View(ProdutoList);
        }
       [HttpPut] 
       public async Task<ActionResult>Edit(int? id)
        {


            ViewBag.Message = "Alteraçao de Produtos";

            var httpClient = new HttpClient();

            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it           


            httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {ticket.Name}");

            var json = await httpClient.GetStringAsync("http://webapiagro.azurewebsites.net/api/Produtos/"+ id.ToString());

            var ProdutoList =  JsonConvert.DeserializeObject<Produto>(json);

            // var model 

            return View(ProdutoList);
        }

        [System.Web.Http.HttpPost]
        public async Task<Produto>Edit(Produto dados)
        {

              // ViewBag.Message = "Alteraçao de Produtos";

            using (HttpClient json = new HttpClient())
            {
                // HttpResponseMessage response = await json.PostAsJsonAsync("hhttp://webapiagro.azurewebsites.net/api/Produtos", dados);
                //return response.Content.ReadAsAsync<ActionResult>().Result;
                    
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it           


                json.DefaultRequestHeaders.Add("Authorization", $"bearer {ticket.Name}");

                MediaTypeWithQualityHeaderValue contentType =new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded");
                json.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await json.PutAsJsonAsync($"http://webapiagro.azurewebsites.net/api/Produtos/{dados.Id}",dados);
                response.EnsureSuccessStatusCode();


                // Deserialize the updated product from the response body.
               // var ProdutoList = JsonConvert.DeserializeObject<Produto>(response.ToString());
                dados = await response.Content.ReadAsAsync<Produto>();
                return dados;
            }


        }

        static async Task<HttpStatusCode> Delete(string id)
        {
            var httpClient = new HttpClient();

            //  var json = await httpClient.GetStringAsync("http://webapiagro.azurewebsites.net/api/Produtos/" + id.ToString());

            HttpResponseMessage response = await httpClient.DeleteAsync($"api/products/{id}");
            return response.StatusCode;
        }

    } 

}