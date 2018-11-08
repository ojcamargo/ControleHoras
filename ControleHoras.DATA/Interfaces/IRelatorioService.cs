using ControleHoras.DATA.Context.Custom;
using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Interfaces
{
    public interface IRelatorioService
    {
        RelatorioHoras ConsultarLancamentos(int profissionalID, DateTime dataInicial, DateTime dataFinal);
        RelatorioFaturamento ConsultarFaturamento(int clienteId, DateTime dataInicial, DateTime dataFinal);
        ICollection<AcompanhamentoDiario> ConsultarLancamentosDiarios(int? clienteId, int? contratoId, int? profissionalId, int? situacaoId);
    }
}
