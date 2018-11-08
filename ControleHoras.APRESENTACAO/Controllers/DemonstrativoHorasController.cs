using System;
using System.Web.Mvc;
using ControleHoras.APRESENTACAO.Attributes;
using ControleHoras.APRESENTACAO.AutoMapper;
using ControleHoras.DATA.Interfaces;
using Pesquisa = ControleHoras.APRESENTACAO.Models.Demonstrativos.Pesquisa;
using Resultado = ControleHoras.APRESENTACAO.Models.Demonstrativos.Resultado;

namespace ControleHoras.APRESENTACAO.Controllers
{
    [SessionAuthorizeAttribute]
    public class DemonstrativoHorasController : Controller
    {
        private readonly IProfissionalService _profissionalService;
        private readonly IDemonstrativoHorasService _demonstrativoService;
        private readonly AutoMapperDemonstrativoHoras _mapperDemonstrativo;


        public DemonstrativoHorasController(IProfissionalService profissionalService, IDemonstrativoHorasService demonstrativoService)
        {
            _profissionalService = profissionalService;
            _demonstrativoService = demonstrativoService;
            _mapperDemonstrativo = new AutoMapperDemonstrativoHoras();
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
                    Resultado.HorasViewModel demonstrativo = _mapperDemonstrativo.Mapear(_demonstrativoService.ConsultarDemonstrativo(model.ProfissionalID));
                    return View("Exibir", demonstrativo);
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
            Resultado.HorasViewModel demonstrativo = _mapperDemonstrativo.Mapear(_demonstrativoService.ConsultarDemonstrativo(model.ProfissionalID));
            return new Rotativa.ViewAsPdf("PDF", demonstrativo);
        }

    }
}