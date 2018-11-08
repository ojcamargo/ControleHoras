using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class ContratoController : Controller
    {
        private readonly IContratoService _contratoService;
        private readonly IClienteService _clienteService;
        private readonly IAlocacaoService _alocacaoService;
        private readonly IProfissionalService _profissionalService;
        private readonly AutoMapperContrato _contratoMapper;
        private readonly AutoMapperAlocacao _alocacaoMaper;
        private readonly AutoMapperProfissional _profissionalMapper;

        public ContratoController()
        {
            
        }

        public ContratoController(IContratoService contratoService, 
            IClienteService clienteService, 
            IAlocacaoService alocacaoService, 
            IProfissionalService profissionalService)
        {
            _contratoService = contratoService;
            _clienteService = clienteService;
            _alocacaoService = alocacaoService;
            _profissionalService = profissionalService;

            _contratoMapper = new AutoMapperContrato();
            _alocacaoMaper = new AutoMapperAlocacao();
            _profissionalMapper = new AutoMapperProfissional();
        }

        /// <summary>
        /// Pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _contratoMapper.Mapear(_contratoService.Listar());
            return View(model);
        }

        /// <summary>
        /// Pagina de detalhes do registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _contratoMapper.Mapear(_contratoService.ConsultarPorId(id));
            return View(model);
        }

        /// <summary>
        /// Pagina de cadastro
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ContratoViewModel model = new ContratoViewModel();
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
        public ActionResult Create(ContratoViewModel model)
        {
            try
            {
                //Necessario carregar a propriedade sempre
                //Se o formulário tiver inconsistência, terá qeu devolver a lista preenchida para não ocorrer erros
                model.ListaClientesAtivos = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome", new ClienteIpViewModel().ClienteID);

                if (ModelState.IsValid)
                {
                    var dominio = _contratoMapper.Mapear(model);
                    _contratoService.Incluir(dominio);
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

        private void CarregarListas(ContratoViewModel model)
        {
            ICollection<ProfissionalViewModel> listaProfissionais = _profissionalMapper.Mapear(_profissionalService.ListarAtivos());
            ICollection<ProfissionalViewModel> listaProfissionaisAlocados = _profissionalMapper.Mapear(_alocacaoService.ListarProfissionais(model.ContratoID));
            if((listaProfissionaisAlocados != null && listaProfissionaisAlocados.Count > 0) &&
                (listaProfissionais != null && listaProfissionais.Count > 0))
            {
                foreach(ProfissionalViewModel p in listaProfissionaisAlocados)
                {
                    var profissional = listaProfissionais.FirstOrDefault(x => x.ProfissionalID == p.ProfissionalID);
                    if (profissional != null)
                        listaProfissionais.Remove(profissional);
                }
            }

            model.ListaProfissionais = new SelectList(listaProfissionais, "ProfissionalID", "Nome", null);
            model.ListaProfissionaisAlocados = new SelectList(listaProfissionaisAlocados, "ProfissionalID", "Nome", null);
        }

        /// <summary>
        /// Pagina de edicao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var model = _contratoMapper.Mapear(_contratoService.ConsultarPorId(id));
            CarregarListas(model);
            return View(model);
        }

        /// <summary>
        /// Confirmar edicao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContratoViewModel model)
        {
            try
            {
                CarregarListas(model);

                if (ModelState.IsValid)
                {
                    var contrato = _contratoMapper.Mapear(model);
                    _contratoService.Atualizar(contrato);
                    if (model.ProfissionaisAlocados != null)
                    {
                        _alocacaoService.RemoverTodos(model.ContratoID);
                        foreach (string profissional in model.ProfissionaisAlocados)
                        {
                            var alocacaoModel = new AlocacaoViewModel()
                            {
                                ContratoID = model.ContratoID,
                                ProfissionalID = Convert.ToInt32(profissional)
                            };

                            var alocacao = _alocacaoMaper.Mapear(alocacaoModel);

                            if (!_alocacaoService.ProfissionalAlocado(alocacao))
                                _alocacaoService.Incluir(alocacao);
                        }
                    }

                    
                    return RedirectToAction("Index", "Contrato");
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
            var model = _contratoMapper.Mapear(_contratoService.ConsultarPorId(id));
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
                var dominio = _contratoService.ConsultarPorId(id);
                if (dominio != null)
                {
                    _alocacaoService.RemoverTodos(dominio.ContratoID);
                    _contratoService.Remover(dominio);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Desativar contrato
        /// </summary>
        /// <param name="id">Código identificador do contrato</param>
        /// <returns></returns>
        public ActionResult Desativar(long id)
        {
            try
            {
                var sistema = _contratoService.ConsultarPorId(id);
                _contratoService.Desativar(sistema);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Reativar contrato
        /// </summary>
        /// <param name="id">Código identificador do contrato</param>
        /// <returns></returns>
        public ActionResult Reativar(long id)
        {
            try
            {
                var sistema = _contratoService.ConsultarPorId(id);
                _contratoService.Reativar(sistema);
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
