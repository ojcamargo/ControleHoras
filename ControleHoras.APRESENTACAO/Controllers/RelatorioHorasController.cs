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
    public class RelatorioHorasController : Controller
    {
        private readonly IProfissionalService _profissionalService;
        private readonly IRelatorioService _relatorioService;
        private readonly AutoMapperRelatorioHoras _mapper;


        public RelatorioHorasController(IProfissionalService profissionalService, IRelatorioService relatorioService)
        {
            _profissionalService = profissionalService;
            _relatorioService = relatorioService;
            _mapper = new AutoMapperRelatorioHoras();
        }

        public ActionResult Index()
        {
            var model = new Pesquisa.HorasViewModel();
            model.Profissionais = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome");
            return View(model);
        }

        [HttpPost]
        public ActionResult Exibir(Pesquisa.HorasViewModel model)
        {
            try
            {
                model.Profissionais = new SelectList(_profissionalService.ListarAtivos(), "ProfissionalID", "Nome", model.ProfissionalID);
                if(ModelState.IsValid)
                {
                    Session["ProfissionalID"] = model.ProfissionalID;
                    Session["DataInicial"] = model.DataInicial;
                    Session["DataFinal"] = model.DataFinal;

                    Resultado.HorasViewModel relatorio = _mapper.Mapear(_relatorioService.ConsultarLancamentos(model.ProfissionalID, model.DataInicial.Value, model.DataFinal.Value));
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

        public ActionResult GeneratePDF(Pesquisa.HorasViewModel model)
        {
            var ProfissionalID = Convert.ToInt32(Session["ProfissionalID"]);
            var DataInicial = Convert.ToDateTime(Session["DataInicial"]);
            var DataFinal = Convert.ToDateTime(Session["DataFinal"]);

            Resultado.HorasViewModel relatorio = _mapper.Mapear(_relatorioService.ConsultarLancamentos(ProfissionalID, DataInicial, DataFinal));

            return new Rotativa.ViewAsPdf("PDF", relatorio);
        }

    }
}