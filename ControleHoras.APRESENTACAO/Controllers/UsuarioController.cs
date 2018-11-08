using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;
using System.Globalization;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProfissionalService _profissionalService;
        private readonly IClienteService _clienteService;

        private readonly AutoMapperUsuario _mapper;

        public UsuarioController()
        {

        }

        public UsuarioController(IUsuarioService usuarioService, IProfissionalService profissionalService, IClienteService clienteService)
        {
            _usuarioService = usuarioService;
            _profissionalService = profissionalService;
            _clienteService = clienteService;
            _mapper = new AutoMapperUsuario();
        }

        /// <summary>
        /// Pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _mapper.Mapear(_usuarioService.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _mapper.Mapear(_usuarioService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            UsuarioCriacaoViewModel model = new UsuarioCriacaoViewModel();
            //Carregar listas de profissionais e clientes
            model.ListaProfissionais = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome", model.ProfissionalID);
            
            model.ListaClientes = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", model.ClienteID);
            return View(model);
        }

        /// <summary>
        /// Confirmar cadasro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioCriacaoViewModel model)
        {
            try
            {
                //Necessario carregar a propriedade sempre
                //Se o formulário tiver inconsistência, terá qeu devolver a lista preenchida para não ocorrer erros
                model.ListaProfissionais = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome", model.ProfissionalID);
                model.ListaClientes = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", model.ClienteID);

                if(model.ProfissionalID > 0)
                {
                    //Remover validacoes de senha para usuaios internos
                    model.Senha = "s/n";
                    model.ConfirmarSenha = "s/n";
                    if (ModelState.ContainsKey("Senha"))
                        ModelState["Senha"].Errors.Clear();
                    if (ModelState.ContainsKey("ConfirmarSenha"))
                        ModelState["ConfirmarSenha"].Errors.Clear();
                }
                if (ModelState.IsValid)
                {
                    var dominio = new AutoMapperUsuarioCriacao().Mapear(model);
                    _usuarioService.Incluir(dominio);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Pagina de edicao dos dados cadastrais
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var model = _mapper.Mapear(_usuarioService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao dos dados cadastrais
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _usuarioService.Atualizar(dominio);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Pagina de edicao da senha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditPassword(int id)
        {
            var model = new AutoMapperUsuarioSenha().Mapear(_usuarioService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao da senha
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(UsuarioSenhaViewModel model)
        {
            try
            {
                //Resgatar valores para apresentar na tela novamente
                AutoMapperUsuarioSenha mapperPasswordView = new AutoMapperUsuarioSenha();
                UsuarioSenhaViewModel valoresOriginais = mapperPasswordView.Mapear(_usuarioService.ConsultarPorIdSemRastreamento(model.UsuarioID));
                model.Login = valoresOriginais.Login;
                model.ProfissionalID = valoresOriginais.ProfissionalID;
                model.Profissional = valoresOriginais.Profissional;
                model.ClienteID = valoresOriginais.ClienteID;
                model.Cliente = valoresOriginais.Cliente;

                if (ModelState.IsValid)
                {
                    var dominio = mapperPasswordView.Mapear(model);
                    _usuarioService.Atualizar(dominio);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Pagina de exclusao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var model = _mapper.Mapear(_usuarioService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar exclusao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComfirmed(long id)
        {
            try
            {
                var dominio = _usuarioService.ConsultarPorId(id);
                _usuarioService.Remover(dominio);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }


    }
}
