using System.Activities.Statements;

using System.Collections.Generic;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System.Linq;

namespace ControleHoras.DATA.Repositories
{
    public class ProfissionalDispositivoRepository : BaseRepository<ProfissionalDispositivo>, IProfissionalDispositivoRepository
    {
        public new ICollection<ProfissionalDispositivo> Listar()
        {
            ICollection<ProfissionalDispositivo> lista = base.Listar();
            lista.ToList().ForEach(p => p.Profissional = Db.Profissional.Find(p.ProfissionalID));
            return lista;
        }

        public new ProfissionalDispositivo ConsultarPorId(long id)
        {
            ProfissionalDispositivo item = base.ConsultarPorId(id);
            item.Profissional = Db.Profissional.Find(item.ProfissionalID);
            return item;
        }

    }
}
