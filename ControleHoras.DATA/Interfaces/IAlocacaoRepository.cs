using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IAlocacaoRepository : IBaseRepository<Alocacao>
    {
        bool ProfissionalAlocado(Alocacao alocacao);
        ICollection<Contrato> ListarContratos();
        ICollection<Contrato> ListarContratos(int profissionalId);
        ICollection<Profissional> ListarProfissionais(int contratoId);

        void RemoverTodos(int contratoId);
    }
}
