using System.Collections.Generic;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IClienteService : IBaseService<Cliente>
    {
        void Desativar(Cliente objeto);
        void Reativar(Cliente objeto);
        ICollection<Cliente> ListarAtivos();
        Cliente ConsultarPorIdSemRastreamento(long id);
    }
}
