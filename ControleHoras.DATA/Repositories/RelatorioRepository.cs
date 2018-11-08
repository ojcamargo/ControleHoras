using ControleHoras.DATA.Context.Custom;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace ControleHoras.DATA.Repositories
{
    public class RelatorioRepository : BaseRepository<RelatorioHoras>, IRelatorioRepository
    {
        /// <summary>
        /// Consultar relatório de lancamento de horas do profissional
        /// </summary>
        /// <param name="profissionalID"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        /// <remarks>Retornar apenas lançamentos que não estão pendentes de aprovação</remarks>
        public ICollection<RelatorioHorasLancamentos> ConsultarLancamentos(int profissionalID, DateTime dataInicial, DateTime dataFinal)
        {
            List<RelatorioHorasLancamentos> lancamentos = new List<RelatorioHorasLancamentos>();
            lancamentos = Db.Database.SqlQuery<RelatorioHorasLancamentos>(@"set dateformat 'YMD'
select
lc.HorarioEntrada as Entrada,
lc.HorarioSaida as Saida,
lc.Atividade,
pr.Nome as Profissional,
ct.NumeroReferencia + ' ' + ct.Descricao as Contrato,
cl.Nome as Cliente
from Profissional pr
inner join Lancamento lc
on pr.ProfissionalID = lc.ProfissionalID
inner join Contrato ct
on lc.ContratoID = ct.ContratoID
inner join Cliente cl
on ct.ClienteID = cl.ClienteID
where lc.ProfissionalID = @profissionalId
and(lc.HorarioEntrada between @dataInicial and @dataFinal)
and(lc.HorarioSaida between @dataInicial and @dataFinal)
and pendente = 1
order by lc.HorarioEntrada, lc.HorarioSaida", 
new SqlParameter("@profissionalId", profissionalID),
new SqlParameter("@dataInicial", dataInicial),
new SqlParameter("@dataFinal", dataFinal)).ToList();
            
            return lancamentos;
        }

        /// <summary>
        /// Consultar relatório de faturamento por contrato
        /// </summary>
        /// <param name="contratoId"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public ICollection<RelatorioFaturamentoLancamentos> ConsultarFaturamento(int clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            List<RelatorioFaturamentoLancamentos> lancamentos = new List<RelatorioFaturamentoLancamentos>();
            lancamentos = Db.Database.SqlQuery<RelatorioFaturamentoLancamentos>(@"set dateformat 'YMD';
with LancamentosCTE (TotalHoras, ValorBase, ValorHora, Profissional, Contrato, Cliente)
as
(
	select
	SUM(DATEDIFF(HOUR, lc.HorarioEntrada, lc.HorarioSaida)) as Horas,
	cast(isnull(ct.ValorHora,0) as decimal(9,2)) as ValorBase,
    cast(isnull(pr.ValorHora,0) as decimal(9,2)) as ValorHora,
	pr.Nome as Profissional,
	ct.NumeroReferencia + ' ' + ct.Descricao as Contrato,
	cl.Nome as Cliente
	from Profissional pr
	inner join Lancamento lc
	on pr.ProfissionalID = lc.ProfissionalID
	inner join Contrato ct
	on lc.ContratoID = ct.ContratoID
	inner join Cliente cl
	on ct.ClienteID = cl.ClienteID
	where ct.ClienteID = @ClienteID
	and(lc.HorarioEntrada between @dataInicial and @dataFinal)
	and(lc.HorarioSaida between @dataInicial and @dataFinal)
	group by 
	ct.ValorHora,
    pr.ValorHora,
	pr.Nome,
	ct.NumeroReferencia,
	ct.Descricao,
	cl.Nome
)
select Profissional, Contrato, Cliente, TotalHoras, 
(TotalHoras * ValorBase) as ValorFaturado,
(TotalHoras * ValorHora) as ValorCusto 
from LancamentosCTE",
new SqlParameter("@ClienteID", clienteId),
new SqlParameter("@dataInicial", dataInicial),
new SqlParameter("@dataFinal", dataFinal)).ToList();

            return lancamentos;
        }

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
        public ICollection<AcompanhamentoDiario> ConsultarLancamentosDiarios(int? clienteId, int? contratoId, int? profissionalId, int? situacaoId)
        {
            ICollection<AcompanhamentoDiario> lancamentos = null;
            lancamentos = Db.Database.SqlQuery<AcompanhamentoDiario>(@";with pr as (
	select pr.ProfissionalID, pr.Nome, pr.HorarioEntrada, pr.HorarioSaida as Profissional 
	from profissional pr
	where pr.Ativo = 1
)
select 
  pr.Nome as Profissional,
  cl.Nome as Cliente, 
  cr.NumeroReferencia + ' ' + cr.Descricao as Contrato,
  (case 
	when lc.LancamentoID is null then 'Presença não registrada' 
	when lc.LancamentoID is not null and convert(time,lc.HorarioEntrada) > pr.HorarioEntrada then 'Presença registrada com atraso'
	when lc.LancamentoID is not null and pr.HorarioEntrada is null then 'Presença registrada'
	when lc.LancamentoID is not null and convert(time,lc.HorarioEntrada) <= pr.HorarioEntrada then 'Presença registrada'
  end) as Situacao
from pr
inner join Alocacao al (nolock) 
  on pr.ProfissionalID = al.ProfissionalID
inner join Contrato cr (nolock) 
  on al.ContratoID = cr.ContratoID
inner join Cliente cl (nolock) 
  on cr.ClienteID = cl.ClienteID
left join Lancamento lc (nolock) 
  on pr.ProfissionalID = lc.ProfissionalID
  and convert(varchar(10),lc.HorarioEntrada,103) = convert(varchar(10),getdate(),103)
  and lc.LancamentoID = (select MIN(LancamentoID) from Lancamento lm (nolock) 
    where lm.ProfissionalID = lc.ProfissionalID and lm.ContratoID = lc.ContratoID)
 ").ToList();
            return lancamentos;
        }

    }
}
