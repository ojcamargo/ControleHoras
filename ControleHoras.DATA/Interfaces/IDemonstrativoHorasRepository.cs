using ControleHoras.DATA.Context.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Interfaces
{
    public interface IDemonstrativoHorasRepository : IBaseRepository<DemonstrativoHoras>
    {
        ICollection<DemonstrativoLancamentos> ConsultarLancamentos(int profissionalID);
    }
}
