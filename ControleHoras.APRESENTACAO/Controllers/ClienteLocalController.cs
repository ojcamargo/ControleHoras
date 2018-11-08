using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ClienteLocalController : Controller
    {
        private readonly IClienteLocalService _localService;
        private readonly IClienteService _clienteService;
        private readonly AutoMapperClienteLocal _mapper;

        public ClienteLocalController()
        {

        }

        public ClienteLocalController(IClienteLocalService localService, IClienteService clienteService)
        {
            _localService = localService;
            _clienteService = clienteService;
            _mapper = new AutoMapperClienteLocal();
        }

        /// <summary>
        /// Pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _mapper.Mapear(_localService.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _mapper.Mapear(_localService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ClienteLocalViewModel model = new ClienteLocalViewModel();
            //Carregar lista de clientes
            model.ListaClientesAtivos = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", new ClienteIpViewModel().ClienteID);
            return View(model);
        }

        /// <summary>
        /// Confirmar cadasro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteLocalViewModel model)
        {
            try
            {
                //Carregar lista de clientes
                model.ListaClientesAtivos = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", new ClienteIpViewModel().ClienteID);

                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _localService.Incluir(dominio);
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
        /// Pagina de edicao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var model = _mapper.Mapear(_localService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteLocalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _localService.Atualizar(dominio);
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
            var model = _mapper.Mapear(_localService.ConsultarPorId(id));
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
                var dominio = _localService.ConsultarPorId(id);
                _localService.Remover(dominio);
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
