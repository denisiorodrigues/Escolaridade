using System.Web.Mvc;

namespace DR.Escolaridade.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "Ocorreu um erro";
            ViewBag.MensagemErro = "Ocorreu um erro, tente novamente ou alerte o administrador";

            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.MensagemErro = "Não existe a página para a URL informada";

            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Aceso negado!";
            ViewBag.MensagemErro = "Você não tem permissão para acessar isso!";

            return View("Error");
        }
    }
}