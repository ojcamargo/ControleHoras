using System.Collections.Generic;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        ICollection<Cliente> ListarAtivos();
        Cliente ConsultarPorIdSemRastreamento(long id);
    }
}
