using System;
using System.Collections.Generic;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Resultado
{
    /// <summary>
    /// Cabeçalho do relatório de horas
    /// </summary>
    public class HorasViewModel
    {
        public string Profissional { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Periodo { get; set; }
        public ICollection<HorasLancamentoViewModel> Lancamentos { get; set; }
    }
}