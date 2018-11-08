using ControleHoras.DATA.Context.Custom;
using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Interfaces
{
    public interface IRelatorioRepository : IBaseRepository<RelatorioHoras>
    {
        /// <summary>
        /// Consultar lançamentos de horas do profissional
        /// </summary>
        /// <param name="profissionalID">código do profissional</param>
        /// <param name="dataInicial">data de início do período de apuração</param>
        /// <param name="dataFinal">data final do período de apuração</param>
        /// <returns></returns>
        ICollection<RelatorioHorasLancamentos> ConsultarLancamentos(int profissionalID, DateTime dataInicial, DateTime dataFinal);
        /// <summary>
        /// Consultar faturameto por cliente
        /// </summary>
        /// <param name="clienteId">Código do cliente</param>
        /// <param name="dataInicial">data de início do período de apuração</param>
        /// <param name="dataFinal">data final do período de apuração</param>
        /// <returns></returns>
        ICollection<RelatorioFaturamentoLancamentos> ConsultarFaturamento(int clienteId, DateTime dataInicial, DateTime dataFinal);
        /// <summary>
        /// Consultar lançamentos diários, e o status de cada profissional
        /// </summary>
        /// <param name="clienteId">Código do cliente</param>
        /// <param name="contratoId">Código do contrato</param>
        /// <param name="profissionalId">Código do profissional</param>
        /// <param name="situacaoId">Código da situação do profissional</param>
        /// <remarks>
        /// situacaoId: 1 - Presença Registrada, 2 - Presença Registrada com Atraso, 3 - Presença Não Registrada
        /// </remarks>
        /// <returns></returns>
        ICollection<AcompanhamentoDiario> ConsultarLancamentosDiarios(int? clienteId, int? contratoId, int? profissionalId, int? situacaoId);
    }
}
