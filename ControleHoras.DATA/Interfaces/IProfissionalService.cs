using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IProfissionalService : IBaseService<Profissional>
    {
        void Desativar(Profissional objeto);
        void Reativar(Profissional objeto);
        ICollection<Profissional> ListarAtivos();
        Profissional ConsultarPorIdSemRastreamento(long id);
    }
}
