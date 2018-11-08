using System.Collections.Generic;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IAlocacaoService : IBaseService<Alocacao>
    {
        bool ProfissionalAlocado(Alocacao alocacao);
        ICollection<Contrato> ListarContratos();
        ICollection<Contrato> ListarContratos(int profissionalId);
        ICollection<Profissional> ListarProfissionais(int contratoId);
        void RemoverTodos(int contratoId);
    }
}
