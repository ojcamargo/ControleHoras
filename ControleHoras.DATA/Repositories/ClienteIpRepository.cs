using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Repositories
{
    public class ClienteIpRepository : BaseRepository<ClienteIp>, IClienteIpRepository
    {
        public new ClienteIp ConsultarPorId(long id)
        {
            ClienteIp item = base.ConsultarPorId(id);
            if (item.ClienteID > 0)
                item.Cliente = Db.Cliente.Find(item.ClienteID);
            return item;
        }
    }
}
