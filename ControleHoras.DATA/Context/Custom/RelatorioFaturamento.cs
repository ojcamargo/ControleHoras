using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context.Custom
{
    public class RelatorioFaturamento
    {
        public string Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Periodo { get; set; }
        public ICollection<RelatorioFaturamentoLancamentos> Lancamentos { get; set; }
    }
}
