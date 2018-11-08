using ControleHoras.DATA.Context;
using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Interfaces
{
    public interface ILancamentoRepository : IBaseRepository<Lancamento>
    {
        Lancamento ConsultarUltimoLancamento(int contratoId, int profissionalId);
        ICollection<Lancamento> BuscarLancamentosProfissional(int profissionalId);
    }
}
