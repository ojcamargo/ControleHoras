using System.ComponentModel.DataAnnotations;

namespace ControleHoras.APRESENTACAO.Models.Demonstrativos.Resultado
{
    /// <summary>
    /// Lançamentos do demonstrativo de horas
    /// </summary>
    public class HorasLancamentoViewModel
    {
        public int ContratoID { get; set; }
        public ContratoViewModel Contrato { get; set; }
        [DisplayFormat(DataFormatString = "{0:G}")]
        public int QtdHoras { get; set; }
        [DisplayFormat(DataFormatString = "{0:G}")]
        public int QtdDiasTrabalhados { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorBase { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorPorContrato { get; set; }
    }
}