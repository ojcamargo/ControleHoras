using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Context.Custom
{
    public class DemonstrativoHoras
    {
        public int ProfissionalID { get; set; }
        public Profissional Profissional { get; set; }
        public ICollection<DemonstrativoLancamentos> Lancamentos { get; set; }
        public DateTime Data { get; set; }
        public string Periodo { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
