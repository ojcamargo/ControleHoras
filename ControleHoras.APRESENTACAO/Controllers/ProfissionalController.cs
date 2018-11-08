using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ProfissionalController : Controller
    {
        private readonly IProfissionalService _service;
        private readonly AutoMapperProfissional _mapper;

        public ProfissionalController()
        {

        }

        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
            _mapper = new AutoMapperProfissional();
        }

        /// <summary>
        /// Pagina inicial
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
        public ActionResult Create(ProfissionalViewModel model)
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
        public ActionResult Edit(ProfissionalViewModel model)
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
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Desativar profissional
        /// </summary>
        /// <param name="id">Código identificador do profissional</param>
        /// <returns></returns>
        public ActionResult Desativar(long id)
        {
            try
            {
                var sistema = _service.ConsultarPorId(id);
                _service.Desativar(sistema);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Reativar profissional
        /// </summary>
        /// <param name="id">Código identificador do profissional</param>
        /// <returns></returns>
        public ActionResult Reativar(long id)
        {
            try
            {
                var sistema = _service.ConsultarPorId(id);
                _service.Reativar(sistema);
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
