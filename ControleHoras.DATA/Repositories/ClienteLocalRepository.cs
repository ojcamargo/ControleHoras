using System.Collections.Generic;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System.Linq;

namespace ControleHoras.DATA.Repositories
{
    public class ClienteLocalRepository : BaseRepository<ClienteLocal>, IClienteLocalRepository
    {
        public new ClienteLocal ConsultarPorId(long id)
        {
            ClienteLocal item = base.ConsultarPorId(id);
            if (item.ClienteID > 0)
                item.Cliente = Db.Cliente.Find(item.ClienteID);
            return item;
        }

        public new ICollection<ClienteLocal> Listar()
        {
            ICollection<ClienteLocal> lista = base.Listar();
            lista.ToList().ForEach(c => c.Cliente = Db.Cliente.Find(c.ClienteID));
            return lista;
        }

    }
}
