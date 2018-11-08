using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.DATA.Interfaces;
using Pesquisa = ControleHoras.APRESENTACAO.Models.Monitoramento.Pesquisa;
using Resultado = ControleHoras.APRESENTACAO.Models.Monitoramento.Resultado;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using WebGrease.Css.Extensions;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class AcompanhamentoDiarioController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IContratoService _contratoService;
        private readonly IProfissionalService _profissionalService;
        private readonly IRelatorioService _relatorioService;
        private readonly AutoMapperContrato _contratoMapper;
        private readonly AutoMapperCliente _clienteMapper;
        private readonly AutoMapperProfissional _profissionalMapper;
        private readonly AutoMapperAcompanhamentoDiario _filtrosMapper;

        public AcompanhamentoDiarioController(IClienteService clienteService,
            IContratoService contratoService,
            IProfissionalService profissionalService,
            IRelatorioService relatorioService)
        {
            _clienteService = clienteService;
            _contratoService = contratoService;
            _profissionalService = profissionalService;
            _relatorioService = relatorioService;
            _contratoMapper = new AutoMapperContrato();
            _clienteMapper = new AutoMapperCliente();
            _profissionalMapper = new AutoMapperProfissional();
            _filtrosMapper = new AutoMapperAcompanhamentoDiario();
        }

        public ActionResult Index()
        {
            var model = new Pesquisa.AcompanhamentoDiarioViewModel();
            model.Profissionais = new SelectList(_profissionalMapper.Mapear(_profissionalService.ListarAtivos()), "ProfissionalID", "Nome");
            model.Clientes = new SelectList(_clienteMapper.Mapear(_clienteService.ListarAtivos()), "ClienteID", "Nome");
            model.Contratos = new SelectList(new Collection<ContratoViewModel>(), "ClienteID", "Nome");
            return View(model);
        }

        [HttpPost]
        public ActionResult Exibir(Pesquisa.AcompanhamentoDiarioViewModel model)
        {
            try
            {
                model.Profissionais = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome");
                model.Clientes = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome");
                if (ModelState.IsValid)
                {
                    Session["ProfissionalID"] = model.ProfissionalID;
                    Session["ClienteID"] = model.ClienteID;
                    Session["ContratoID"] = model.ContratoID;
                    Session["SituacaoID"] = model.SituacaoID;

                    ICollection<Resultado.AcompanhamentoDiarioViewModel> relatorio = _filtrosMapper.Mapear(_relatorioService.ConsultarLancamentosDiarios(model.ProfissionalID, model.ClienteID, model.ProfissionalID, model.SituacaoID));
                    return View("Exibir", relatorio);
                }
                return View("Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        public ActionResult GeneratePDF(Pesquisa.AcompanhamentoDiarioViewModel model)
        {
            var ProfissionalID = Convert.ToInt32(Session["ProfissionalID"]);
            var DataInicial = Convert.ToDateTime(Session["DataInicial"]);
            var DataFinal = Convert.ToDateTime(Session["DataFinal"]);

            ICollection<Resultado.AcompanhamentoDiarioViewModel> relatorio = _filtrosMapper.Mapear(_relatorioService.ConsultarLancamentosDiarios(model.ProfissionalID, model.ClienteID, model.ProfissionalID, model.SituacaoID));

            return new Rotativa.ViewAsPdf("PDF", relatorio);
        }

        [HttpPost]
        public ActionResult ListarContratos(int clienteId)
        {
            ICollection<ContratoViewModel> contratos = null;
            List<ContratoViewModel> contratosCliente = new List<ContratoViewModel>();
            if (clienteId > 0)
                contratos = _contratoMapper.Mapear(_contratoService.ListarAtivos());
            return Json(contratos, JsonRequestBehavior.AllowGet);
        }
    }
}