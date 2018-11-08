using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleHoras.APRESENTACAO.Models.Demonstrativos.Resultado
{
    /// <summary>
    /// Cabeçalho do demonstrativo de horas
    /// </summary>
    public class HorasViewModel
    {
        public int ProfissionalID { get; set; }
        public ProfissionalViewModel Profissional { get; set; }
        public string Periodo { get; set; }
        public DateTime Data { get; set; }

        public ICollection<HorasLancamentoViewModel> Lancamentos { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorTotal { get; set; }
    }
}