using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Interfaces;
using System;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class LancamentoController : Controller
    {
        private readonly ILancamentoService _lancamentoService;
        private readonly IAlocacaoService _alocacaoService;
        private readonly IProfissionalService _profissionalService;
        private readonly AutoMapperLancamento _lancamentoMapper;
        private readonly AutoMapperLancamentoEdicao _edicaoMapper;
        private readonly AutoMapperProfissional _profissionalMapper;

        public LancamentoController()
        {

        }

        public LancamentoController(ILancamentoService lancamentoService, IAlocacaoService alocacaoService, IProfissionalService profissionalService)
        {
            _lancamentoService = lancamentoService;
            _alocacaoService = alocacaoService;
            _profissionalService = profissionalService;
            _lancamentoMapper = new AutoMapperLancamento();
            _profissionalMapper = new AutoMapperProfissional();
            _edicaoMapper = new AutoMapperLancamentoEdicao();
        }

        /// <summary>
        /// Pagina de apontamento de hóras
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (!ValidarUsuario())
            {
                Session["usuario"] = null;
                return RedirectToAction("Index", "Home");
            }


            var model = new LancamentoViewModel();

            
            model.ProfissionalID = ((UsuarioViewModel)Session["usuario"]).Profissional.ProfissionalID;
            model.Profissional = ((UsuarioViewModel)Session["usuario"]).Profissional;

            model.Contratos = new SelectList(_alocacaoService.ListarContratos(model.ProfissionalID), "ContratoID", "DescricaoCompleta", model.ContratoID);
            return View(model);
        }

        /// <summary>
        /// Página de pesquisa de lançamentos
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            if (!ValidarUsuarioAdm())
            {
                Session["usuario"] = null;
                return RedirectToAction("Index", "Home");
            }
            
            var model = new LancamentoPesquisaViewModel();
            model.Profissionais = new SelectList(_profissionalMapper.Mapear(_profissionalService.ListarAtivos()), "ProfissionalID", "Nome");
            return View(model);
        }

        [HttpPost]
        public JsonResult ConsultarUltimoLancamento(int contratoId, int profissionalId)
        {
            LancamentoViewModel ultimoLancamento = new LancamentoViewModel();
            var dominio = _lancamentoService.ConsultarUltimoLancamento(contratoId, profissionalId);
            if (dominio != null)
                ultimoLancamento = _lancamentoMapper.Mapear(dominio);
            else
            {
                ultimoLancamento.ContratoID = contratoId;
                ultimoLancamento.ProfissionalID = profissionalId;
                ultimoLancamento.PermitirEntrada = true;
            }
            return Json(ultimoLancamento);
        }

        /// <summary>
        /// Entrada
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Entrada(LancamentoViewModel model)
        {
            try
            {
                _lancamentoService.Entrada(_lancamentoMapper.Mapear(model));
                return Json("sucesso");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Saida
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Saida(LancamentoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _lancamentoService.Saida(_lancamentoMapper.Mapear(model));
                    return Json("sucesso");
                }
                return Json("inconsistente");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Exibir lançamentos do profissional para edição
        /// </summary>
        /// <param name="profissionalId"></param>
        /// <returns></returns>
        public PartialViewResult BuscarLancamentosProfissional(int profissionalId)
        {
            var model = _edicaoMapper.Mapear(_lancamentoService.BuscarLancamentosProfissional(profissionalId));
            return PartialView("Edit", model);
        }

        /// <summary>
        /// Editar lançamento
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Atualizar(LancamentoEdicaoViewModel lancamento)
        {
            try
            {
                _lancamentoService.Atualizar(_edicaoMapper.Mapear(lancamento));
                return Json("sucesso");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Excluir lançamento
        /// </summary>
        /// <param name="lancamentoId">Código identificador do lançamento</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Excluir(int lancamentoId)
        {
            try
            {
                _lancamentoService.Remover(lancamentoId);
                return Json("sucesso");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Excluir lançamento
        /// </summary>
        /// <param name="lancamentoId">Código identificador do lançamento</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Aprovar(int lancamentoId)
        {
            try
            {
                _lancamentoService.Aprovar(lancamentoId);
                return Json("sucesso");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Validar se usuario possui perfil para efetuar apontamenot de horas
        /// </summary>
        /// <returns></returns>
        private bool ValidarUsuario()
        {
            bool usuarioValido = true;
            if (Session["usuario"] == null)
                usuarioValido = false;
            else
            {
                UsuarioViewModel usuario = (UsuarioViewModel)Session["usuario"];
                if (usuario.ProfissionalID == null)
                    usuarioValido = false;
                else if (usuario.ProfissionalID <= 0)
                    usuarioValido = false;
            }
            return usuarioValido;
        }

        /// <summary>
        /// Verifica se o usuario possui perfil administrativo
        /// </summary>
        /// <returns></returns>
        private bool ValidarUsuarioAdm()
        {
            bool usuarioValido = true;
            if (Session["usuario"] == null)
                usuarioValido = false;
            else
            {
                UsuarioViewModel usuario = (UsuarioViewModel)Session["usuario"];
                usuarioValido = usuario.Adm;
            }
            return usuarioValido;
        }


        
    }
}
