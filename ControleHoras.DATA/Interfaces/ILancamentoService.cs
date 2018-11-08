using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface ILancamentoService : IBaseService<Lancamento>
    {
        void Entrada(Lancamento model);

        void Saida(Lancamento model);

        Lancamento ConsultarUltimoLancamento(int contratoId, int profissionalId);

        ICollection<Lancamento> BuscarLancamentosProfissional(int profissionalId);

        void Aprovar(long lancamentoId);
        void Remover(int lancamentoId);
    }
}
