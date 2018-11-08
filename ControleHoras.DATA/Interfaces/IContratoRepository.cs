using System.Collections.Generic;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IContratoRepository : IBaseRepository<Contrato>
    {
        ICollection<Contrato> ListarAtivos();
        Contrato ConsultarPorIdSemRastreamento(long id);
    }
}
