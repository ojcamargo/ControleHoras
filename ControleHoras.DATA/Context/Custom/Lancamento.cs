using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context
{
    public partial class Lancamento
    {
        public bool PermitirEntrada { get; set; }
        public bool PermitirSaida { get; set; }
    }
}
