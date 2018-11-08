using System.Collections.Generic;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IContratoService : IBaseService<Contrato>
    {
        void Desativar(Contrato objeto);
        void Reativar(Contrato objeto);
        ICollection<Contrato> ListarAtivos();
        Contrato ConsultarPorIdSemRastreamento(long id);
    }
}
