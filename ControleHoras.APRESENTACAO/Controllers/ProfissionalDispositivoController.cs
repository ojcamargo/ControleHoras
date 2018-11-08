using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ProfissionalDispositivoController : Controller
    {
        private readonly IProfissionalDispositivoService _dispositivoService;
        private readonly IProfissionalService _profissionalService;
        private readonly AutoMapperProfissionalDispositivo _mapper;

        public ProfissionalDispositivoController()
        {

        }

        public ProfissionalDispositivoController(IProfissionalDispositivoService dispositivoService, IProfissionalService profissionalService)
        {
            _dispositivoService = dispositivoService;
            _profissionalService = profissionalService;
            _mapper = new AutoMapperProfissionalDispositivo();
        }

        /// <summary>
        /// Pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _mapper.Mapear(_dispositivoService.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _mapper.Mapear(_dispositivoService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ProfissionalDispositivoViewModel model = new ProfissionalDispositivoViewModel();
            //Carregar lista de profissionais
            model.ListaProfissionaisAtivos = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome", model.ProfissionalID);
            return View(model);
        }

        /// <summary>
        /// Confirmar cadasro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfissionalDispositivoViewModel model)
        {
            try
            {
                //Necessario carregar a propriedade sempre
                //Se o formulário tiver inconsistência, terá qeu devolver a lista preenchida para não ocorrer erros
                model.ListaProfissionaisAtivos = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome", model.ProfissionalID);

                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _dispositivoService.Incluir(dominio);
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
            var model = _mapper.Mapear(_dispositivoService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfissionalDispositivoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dominio = _mapper.Mapear(model);
                    _dispositivoService.Atualizar(dominio);
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
            var model = _mapper.Mapear(_dispositivoService.ConsultarPorId(id));
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
                var dominio = _dispositivoService.ConsultarPorId(id);
                _dispositivoService.Remover(dominio);
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
