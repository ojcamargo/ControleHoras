using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleHoras.DATA.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public Lancamento ConsultarUltimoLancamento(int contratoId, int profissionalId)
        {
            Lancamento lancamento = null;
            var maxValue = Db.Lancamento.Where(x => x.ContratoID == contratoId && 
                                        x.ProfissionalID == profissionalId).Max(x => (int?)x.LancamentoID) ?? 0;
            if (maxValue > 0)
            {
                lancamento = Db.Lancamento.Where(x => x.LancamentoID == maxValue).First();
                if (lancamento != null)
                {
                    lancamento.Profissional = Db.Profissional.Where(x => x.ProfissionalID == lancamento.ProfissionalID).FirstOrDefault();
                    lancamento.Contrato = Db.Contrato.Where(x => x.ContratoID == lancamento.ContratoID).FirstOrDefault();
                }
            }
            return lancamento;
        }

        public ICollection<Lancamento> BuscarLancamentosProfissional(int profissionalId)
        {
            DateTime dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddMonths(1).AddDays(DateTime.Now.Day * -1).Day, 23, 59, 59);
            var lista = Db.Lancamento.Where(x => x.HorarioEntrada >= dataInicial
                                            && x.HorarioEntrada <= dataFinal
                                            && x.ProfissionalID == profissionalId).ToList();
            if(lista != null && lista.Count > 0)
            {
                foreach(Lancamento lancamento in lista)
                {
                    lancamento.Profissional = Db.Profissional.Where(x => x.ProfissionalID == lancamento.ProfissionalID).FirstOrDefault();
                    lancamento.Contrato = Db.Contrato.Where(x => x.ContratoID == lancamento.ContratoID).FirstOrDefault();
                }
            }
            return lista;
        }

    }
}
