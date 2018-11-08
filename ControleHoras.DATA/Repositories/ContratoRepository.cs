using System.Collections.Generic;
using System.Linq;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Repositories
{
    public class ContratoRepository : BaseRepository<Contrato>, IContratoRepository
    {
        public ICollection<Contrato> ListarAtivos()
        {
            return Db.Contrato.Where(x => x.Ativo == true).ToList();
        }

        public new ICollection<Contrato> Listar()
        {
            ICollection<Contrato> lista = base.Listar();
            lista.ToList().ForEach(c => c.Cliente = Db.Cliente.Find(c.ClienteID));
            return lista;
        }

        public new Contrato ConsultarPorId(long id)
        {
            Contrato item = base.ConsultarPorId(id);
            item.Cliente = Db.Cliente.Find(item.ClienteID);
            return item;
        }

        public Contrato ConsultarPorIdSemRastreamento(long id)
        {
            return Db.Contrato.AsNoTracking().Single(x => x.ContratoID == id);
        }
    }
}
