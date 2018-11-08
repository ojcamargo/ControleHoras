using System;
using System.Collections.Generic;
using System.Linq;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Repositories
{
    public class ProfissionalRepository : BaseRepository<Profissional>, IProfissionalRepository
    {
        public ICollection<Profissional> ListarAtivos()
        {
            return Db.Profissional.Where(x => x.Ativo == true).ToList();
        }

        public Profissional ConsultarPorIdSemRastreamento(long id)
        {
            return Db.Profissional.AsNoTracking().Single(x => x.ProfissionalID == id);
        }
    }
}
