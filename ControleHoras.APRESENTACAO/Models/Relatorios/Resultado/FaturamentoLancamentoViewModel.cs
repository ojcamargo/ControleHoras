using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Resultado
{
    /// <summary>
    /// Lançamentos do relatório de faturamento
    /// </summary>
    public class FaturamentoLancamentoViewModel
    {

        public string Profissional { get; set; }
        public string Contrato { get; set; }
        public string Cliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:G}")]
        public int TotalHoras { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorFaturado { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorCusto { get; set; }
    }
}