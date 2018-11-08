using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.DATA.Context.Custom;
using Resultado = ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperRelatorioFaturamento : IAutoMapper<Resultado.FaturamentoViewModel, RelatorioFaturamento>
    {

        private readonly AutoMapperRelatorioFaturamentoLancamentos _lancamentosMapper;

        public AutoMapperRelatorioFaturamento()
        {
            _lancamentosMapper = new AutoMapperRelatorioFaturamentoLancamentos();
        }

        public ICollection<RelatorioFaturamento> Mapear(ICollection<Resultado.FaturamentoViewModel> dados)
        {
            Collection<RelatorioFaturamento> lista = new Collection<RelatorioFaturamento>();
            foreach (Resultado.FaturamentoViewModel source in dados)
            {
                RelatorioFaturamento destination = new RelatorioFaturamento();
                destination.DataEmissao = source.DataEmissao;
                destination.Periodo = source.Periodo;
                destination.Cliente = source.Periodo;
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

        public RelatorioFaturamento Mapear(Resultado.FaturamentoViewModel dados)
        {
            RelatorioFaturamento destination = new RelatorioFaturamento();
            destination.DataEmissao = dados.DataEmissao;
            destination.Periodo = dados.Periodo;
            destination.Cliente = dados.Periodo;
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public Resultado.FaturamentoViewModel Mapear(RelatorioFaturamento dados)
        {
            Resultado.FaturamentoViewModel destination = new Resultado.FaturamentoViewModel();
            destination.DataEmissao = dados.DataEmissao;
            destination.Periodo = dados.Periodo;
            destination.Cliente = dados.Periodo;
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public ICollection<Resultado.FaturamentoViewModel> Mapear(ICollection<RelatorioFaturamento> dados)
        {
            Collection<Resultado.FaturamentoViewModel> lista = new Collection<Resultado.FaturamentoViewModel>();
            foreach (RelatorioFaturamento source in dados)
            {
                Resultado.FaturamentoViewModel destination = new Resultado.FaturamentoViewModel();
                destination.DataEmissao = source.DataEmissao;
                destination.Periodo = source.Periodo;
                destination.Cliente = source.Periodo;
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

    }
}