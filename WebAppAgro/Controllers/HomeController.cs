using System.Web.Mvc;

namespace WebAppAgro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcessoNegado()
        {
            ViewBag.Message = "Usuário não Autorizado !!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}