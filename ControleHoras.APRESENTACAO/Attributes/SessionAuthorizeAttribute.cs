using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Attributes
{
    /// <summary>
    /// Atributo para verificar se usuário tem autorização para acessar a página
    /// </summary>
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session["usuario"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Login/Index");
        }
    }
}