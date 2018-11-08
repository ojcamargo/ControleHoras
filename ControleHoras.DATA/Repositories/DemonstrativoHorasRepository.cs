using ControleHoras.DATA.Context.Custom;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControleHoras.DATA.Repositories
{
    public class DemonstrativoHorasRepository : BaseRepository<DemonstrativoHoras>, IDemonstrativoHorasRepository
    {
        /// <summary>
        /// Consultar total de horas por contrato
        /// </summary>
        /// <param name="profissionalID"></param>
        /// <returns></returns>
        public ICollection<DemonstrativoLancamentos> ConsultarLancamentos(int profissionalID)
        {
            List<DemonstrativoLancamentos> lancamentos = new List<DemonstrativoLancamentos>();
            lancamentos = Db.Database.SqlQuery<DemonstrativoLancamentos>(string.Format(@"declare @firstDay date, @lastDay date
select @firstDay = dateadd(m, -1, dateadd(d, -(day(getdate() - 1)), getdate()))--first day
select @lastDay = dateadd(m, -1, dateadd(d, -(day(dateadd(m, 1, getdate()))), dateadd(m, 1, getdate())))--last day

select ContratoID, 
sum(DATEDIFF(hour, horarioentrada, horariosaida)) as QtdHoras,
cast(round(cast(sum(DATEDIFF(hour, horarioentrada, horariosaida)) as decimal(9,2)) / 8,0) as int)  as QtdDiasTrabalhados
from Lancamento
where ProfissionalID = {0}
and(horarioentrada between @firstDay and @lastDay)
and(HorarioSaida between @firstDay and @lastDay)
and DATEDIFF(hour, horarioentrada, horariosaida) <= 8
group by ContratoID", profissionalID)).ToList();

            if(lancamentos != null && lancamentos.Count > 0)
            {
                foreach (DemonstrativoLancamentos item in lancamentos)
                {
                    
                    if (item.ContratoID > 0)
                    {
                        item.Contrato = Db.Contrato.Where(x => x.ContratoID == item.ContratoID).FirstOrDefault();
                        if(item.Contrato != null)
                        {
                            item.Contrato.Cliente = Db.Cliente.Where(x => x.ClienteID == item.Contrato.ClienteID).FirstOrDefault();
                        }
                    }
                    
                }
            }
            
            return lancamentos;
        }
    }
}
