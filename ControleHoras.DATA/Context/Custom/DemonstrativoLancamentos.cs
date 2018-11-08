using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context.Custom
{
    public class DemonstrativoLancamentos
    {
        public int ContratoID { get; set; }
        public Contrato Contrato { get; set; }
        public int QtdHoras { get; set; }
        public int QtdDiasTrabalhados { get; set; }
        public decimal ValorBase { get; set; }
        public decimal ValorPorContrato { get; set; }
    }
}
