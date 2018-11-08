using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;
        private readonly AutoMapperCliente _mapper;

        public ClienteController()
        {

        }

        public ClienteController(IClienteService service)
        {
            _service = service;
            _mapper = new AutoMapperCliente();
        }

        /// <summary>
        /// Pagina Inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Pagina de pesquisa
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            var model = _mapper.Mapear(_service.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _mapper.Mapear(_service.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Confirmar cadasro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _service.Incluir(dominio);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception ex)
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
            var model = _mapper.Mapear(_service.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _service.Atualizar(dominio);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception ex)
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
            var model = _mapper.Mapear(_service.ConsultarPorId(id));
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
                var dominio = _service.ConsultarPorId(id);
                _service.Remover(dominio);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Desativar cliente
        /// </summary>
        /// <param name="id">Código identificador do registro</param>
        /// <returns></returns>
        public ActionResult Desativar(long id)
        {
            try
            {
                var registro = _service.ConsultarPorId(id);
                _service.Desativar(registro);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Reativar registro
        /// </summary>
        /// <param name="id">Código identificador do cliente</param>
        /// <returns></returns>
        public ActionResult Reativar(long id)
        {
            try
            {
                var registro = _service.ConsultarPorId(id);
                _service.Reativar(registro);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

    }
}
