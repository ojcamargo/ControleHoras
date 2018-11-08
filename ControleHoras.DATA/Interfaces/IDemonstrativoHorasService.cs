using ControleHoras.DATA.Context.Custom;
using System.Collections.Generic;

namespace ControleHoras.DATA.Interfaces
{
    public interface IDemonstrativoHorasService
    {
        DemonstrativoHoras ConsultarDemonstrativo(int profissionalID);
    }
}
