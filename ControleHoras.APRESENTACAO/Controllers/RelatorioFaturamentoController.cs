using System;
using System.Web.Mvc;
using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.DATA.Interfaces;
using Pesquisa = ControleHoras.APRESENTACAO.Models.Relatorios.Pesquisa;
using Resultado = ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class RelatorioFaturamentoController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IRelatorioService _relatorioService;
        private readonly AutoMapperRelatorioFaturamento _mapper;


        public RelatorioFaturamentoController(IClienteService clienteService, IRelatorioService relatorioService)
        {
            _clienteService = clienteService;
            _relatorioService = relatorioService;
            _mapper = new AutoMapperRelatorioFaturamento();
        }

        public ActionResult Index()
        {
            var model = new Pesquisa.FaturamentoViewModel();
            model.Clientes = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome");
            return View(model);
        }

        [HttpPost]
        public ActionResult Exibir(Pesquisa.FaturamentoViewModel model)
        {
            try
            {
                model.Clientes = new SelectList(_clienteService.ListarAtivos(), "ClienteID", "Nome");
                if (ModelState.IsValid)
                {
                    Session["ClienteID"] = model.ClienteID;
                    Session["DataInicial"] = model.DataInicial;
                    Session["DataFinal"] = model.DataFinal;

                    Resultado.FaturamentoViewModel relatorio = _mapper.Mapear(_relatorioService.ConsultarFaturamento(model.ClienteID, model.DataInicial.Value, model.DataFinal.Value));
                    return View("Exibir", relatorio);
                }
                return View("Index", model);
            }
            catch(Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Error");
            }
        }

        public ActionResult GeneratePDF(Pesquisa.FaturamentoViewModel model)
        {
            var ClienteID = Convert.ToInt32(Session["ClienteID"]);
            var DataInicial = Convert.ToDateTime(Session["DataInicial"]);
            var DataFinal = Convert.ToDateTime(Session["DataFinal"]);

            Resultado.FaturamentoViewModel relatorio = _mapper.Mapear(_relatorioService.ConsultarFaturamento(ClienteID, DataInicial, DataFinal));
            return new Rotativa.ViewAsPdf("PDF", relatorio);
        }

    }
}