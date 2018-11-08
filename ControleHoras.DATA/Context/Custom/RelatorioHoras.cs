using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Context.Custom
{
    public class RelatorioHoras
    {
        public string Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Periodo { get; set; }
        public ICollection<RelatorioHorasLancamentos> Lancamentos { get; set; }
        public string Profissional { get; set; }
    }

    

}
