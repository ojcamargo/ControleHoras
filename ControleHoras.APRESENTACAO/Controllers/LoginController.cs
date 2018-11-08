using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Net;
using System.Security;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioService _service;
        private readonly AutoMapperUsuario _mapper;

        public LoginController()
        {

        }

        public LoginController(IUsuarioService service)
        {
            _service = service;
            _mapper = new AutoMapperUsuario();
        }

        public ActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        public ActionResult Alocacao()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Alocacao");
        }

        public ActionResult Cliente()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Contrato()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Contrato");
        }

        public ActionResult Lancamento()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            UsuarioViewModel usuario = (UsuarioViewModel)Session["usuario"];
            if (usuario.ProfissionalID > 0)
                return RedirectToAction("Index", "Lancamento");
            else
                return RedirectToAction("Search", "Lancamento");
        }

        public ActionResult Profissional()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Profissional");
        }

        public ActionResult Usuario()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Relatorio()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Relatorio");
        }

        public ActionResult HorasExtras()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            UsuarioViewModel usuario = (UsuarioViewModel)Session["usuario"];
            if (usuario.ClienteID.HasValue && usuario.ClienteID.Value > 0)
                return RedirectToAction("Create", "HorasExtras");
            else if(usuario.Adm)
                return RedirectToAction("Index", "HorasExtras");
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult DemonstrativoHoras()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "DemonstrativoHoras");
        }

        public ActionResult RelatorioHoras()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "RelatorioHoras");
        }

        public ActionResult RelatorioFaturamento()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "RelatorioFaturamento");
        }

        public ActionResult AcompanhamentoDiario()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "AcompanhamentoDiario");
        }
  
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UsuarioViewModel usuario = null;
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ModoAutenticacao == LoginViewModel.Dominio.Computecnica)
                    {
                        SecureString pwd = new SecureString();
                        foreach (char c in model.Senha)
                            pwd.AppendChar(c);

                        if (ValidarContaExchange(model.Login, pwd))
                        {
                            usuario = _mapper.Mapear(_service.ValidarUsuario(model.Login));
                        }
                    }
                    else
                    {
                        usuario = _mapper.Mapear(_service.ValidarUsuario(model.Login, model.Senha));
                    }

                    if (usuario != null)
                    {
                        Session["usuario"] = usuario;
                        if (usuario.Adm == true || usuario.Login == "cpt")
                            return RedirectToAction("Index", "Cliente");
                        else
                            return RedirectToAction("Index", "Lancamento");
                    }
                    else
                    {
                        ModelState.AddModelError("CustomMessage", "Usuário ou senha incorretos");
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("CustomMessage", ex.Message);
                }

            }
            return View("Index", model);
        }

        public ActionResult LogOut()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Home");
        }

        private bool ValidarContaExchange(string userprincipalname, SecureString password)
        {
            ExchangeService service = new ExchangeService();
            bool authenticated = false;
            try
            {
                userprincipalname += "@computecnica.com.br";
                service.Credentials = new NetworkCredential(userprincipalname, password);
                if (service.Url == null)
                {
                    service.AutodiscoverUrl(userprincipalname, RedirectionUrlValidationCallback);
                }
                //AlternateIdBase response = service.ConvertId(new AlternateId(IdFormat.EwsId, "Placeholder", userprincipalname), IdFormat.EwsId);
                authenticated = true;
            }

            // The user principal name is in a bad format.
            catch (FormatException ex)
            {
                throw new Exception("Identidade de usuário não é válida");
            }

            catch (AutodiscoverLocalException)
            {
                throw new ApplicationException("Não foi possível localizar as credenciais informadas.");
            }
            catch (ServiceVersionException)
            {
                //conectado ao servidor mas não foi possivel obter ConvertID
                authenticated = true;
            }
            catch (ServiceResponseException)
            {
                //conectado ao servidor mas não foi possivel obter ConvertID
                authenticated = true;
            }
            catch (ServiceRequestException)
            {
                throw new ApplicationException("Credenciais não são válias.");
            }
            
            return authenticated;
        }

        internal static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;
            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
                result = true;
            return result;
        }

    }
}
