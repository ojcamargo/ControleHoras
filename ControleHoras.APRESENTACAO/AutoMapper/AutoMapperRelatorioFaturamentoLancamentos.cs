using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.DATA.Context.Custom;
using Resultado = ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperRelatorioFaturamentoLancamentos : IAutoMapper<Resultado.FaturamentoLancamentoViewModel, RelatorioFaturamentoLancamentos>
    {

        public AutoMapperRelatorioFaturamentoLancamentos()
        {

        }

        public ICollection<RelatorioFaturamentoLancamentos> Mapear(ICollection<Resultado.FaturamentoLancamentoViewModel> dados)
        {
            Collection<RelatorioFaturamentoLancamentos> lista = new Collection<RelatorioFaturamentoLancamentos>();
            foreach (Resultado.FaturamentoLancamentoViewModel source in dados)
            {
                RelatorioFaturamentoLancamentos destination = new RelatorioFaturamentoLancamentos();
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Profissional = source.Profissional;
                destination.TotalHoras = source.TotalHoras;
                destination.ValorCusto = source.ValorCusto;
                destination.ValorFaturado = source.ValorFaturado;
                lista.Add(destination);
            }
            return lista;
        }

        public RelatorioFaturamentoLancamentos Mapear(Resultado.FaturamentoLancamentoViewModel dados)
        {
            RelatorioFaturamentoLancamentos destination = new RelatorioFaturamentoLancamentos();
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Profissional = dados.Profissional;
            destination.TotalHoras = dados.TotalHoras;
            destination.ValorCusto = dados.ValorCusto;
            destination.ValorFaturado = dados.ValorFaturado;
            return destination;
        }

        public Resultado.FaturamentoLancamentoViewModel Mapear(RelatorioFaturamentoLancamentos dados)
        {
            Resultado.FaturamentoLancamentoViewModel destination = new Resultado.FaturamentoLancamentoViewModel();
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Profissional = dados.Profissional;
            destination.TotalHoras = dados.TotalHoras;
            destination.ValorCusto = dados.ValorCusto;
            destination.ValorFaturado = dados.ValorFaturado;
            return destination;
        }

        public ICollection<Resultado.FaturamentoLancamentoViewModel> Mapear(ICollection<RelatorioFaturamentoLancamentos> dados)
        {
            Collection<Resultado.FaturamentoLancamentoViewModel> lista = new Collection<Resultado.FaturamentoLancamentoViewModel>();
            foreach (RelatorioFaturamentoLancamentos source in dados)
            {
                Resultado.FaturamentoLancamentoViewModel destination = new Resultado.FaturamentoLancamentoViewModel();
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Profissional = source.Profissional;
                destination.TotalHoras = source.TotalHoras;
                destination.ValorCusto = source.ValorCusto;
                destination.ValorFaturado = source.ValorFaturado;
                lista.Add(destination);
            }
            return lista;
        }
    }
}