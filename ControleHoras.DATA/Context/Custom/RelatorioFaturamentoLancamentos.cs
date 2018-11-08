using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context.Custom
{
    public class RelatorioFaturamentoLancamentos
    {

        public string Profissional { get; set; }
        public string Contrato { get; set; }
        public string Cliente { get; set; }
        public int TotalHoras { get; set; }
        public decimal ValorFaturado { get; set; }
        public decimal ValorCusto { get; set; }
    }
}
