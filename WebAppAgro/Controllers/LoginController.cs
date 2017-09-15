using RestSharp;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WebAppAgro.Models;

namespace WebAppAgro.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var client = new RestClient("http://webapiagro.azurewebsites.net");

            var request = new RestRequest("api/security/token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", Username);
            request.AddParameter("password", Password);

            IRestResponse<TokenViewModel> response = client.Execute<TokenViewModel>(request);
            var token = response.Data.access_token;



            if (!String.IsNullOrEmpty(token))
            {
                FormsAuthentication.SetAuthCookie(token, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("AcessoNegado", "Home");
                FormsAuthentication.RedirectToLoginPage();
            }


            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    
    }
}