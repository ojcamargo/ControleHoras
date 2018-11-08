using System.Collections.Generic;
using System.Linq;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ICollection<Cliente> ListarAtivos()
        {
            return Db.Cliente.Where(x => x.Ativo == true).ToList();
        }

        public Cliente ConsultarPorIdSemRastreamento(long id)
        {
            return Db.Cliente.AsNoTracking().Single(x => x.ClienteID == id);
        }

    }
}
