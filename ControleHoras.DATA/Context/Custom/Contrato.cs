using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Context
{
    public partial class Contrato
    {
        public string DescricaoCompleta
        {
            get
            {
                return string.Format("{0} {1}", NumeroReferencia, Descricao);
            }
        }
    }
}
