using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ClienteIpController : Controller
    {
        private readonly IClienteIpService _ipService;
        private readonly IClienteService _clienteService;
        private readonly AutoMapperClienteIp _mapper;

        public ClienteIpController()
        {

        }

        public ClienteIpController(IClienteIpService ipService, IClienteService clienteService)
        {
            _ipService = ipService;
            _clienteService = clienteService;
            _mapper = new AutoMapperClienteIp();
        }

        /// <summary>
        /// Pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _mapper.Mapear(_ipService.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _mapper.Mapear(_ipService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ClienteIpViewModel model = new ClienteIpViewModel();
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
        public ActionResult Create(ClienteIpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Carregar lista de clientes
                    model.ListaClientesAtivos = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", new ClienteIpViewModel().ClienteID);

                    var dominio = _mapper.Mapear(model);
                    _ipService.Incluir(dominio);
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
            var model = _mapper.Mapear(_ipService.ConsultarPorId(id));
            //Carregar lista de clientes
            model.ListaClientesAtivos = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", new ClienteIpViewModel().ClienteID);
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteIpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _ipService.Atualizar(dominio);
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
            var model = _mapper.Mapear(_ipService.ConsultarPorId(id));
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
                var dominio = _ipService.ConsultarPorId(id);
                _ipService.Remover(dominio);
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
