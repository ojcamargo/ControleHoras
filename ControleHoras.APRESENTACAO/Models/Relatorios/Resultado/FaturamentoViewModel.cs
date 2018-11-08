using System;
using System.Collections.Generic;
using ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Resultado
{
    /// <summary>
    /// Cabeçalho do relatório de faturamento
    /// </summary>
    public class FaturamentoViewModel
    {
        public string Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Periodo { get; set; }
        public ICollection<FaturamentoLancamentoViewModel> Lancamentos { get; set; }
    }
    
}