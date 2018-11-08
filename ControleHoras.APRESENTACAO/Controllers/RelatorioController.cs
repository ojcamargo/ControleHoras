using ControleHoras.APRESENTACAO.Attributes;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class RelatorioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}