using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context.Custom
{
    public class RelatorioHorasLancamentos
    {
        public string Contrato { get; set; }
        public string Cliente { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string Atividade { get; set; }
    }
}
