using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;
using ControleHoras.DATA.Context.Custom;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperRelatorioHorasLancamentos : IAutoMapper<HorasLancamentoViewModel, RelatorioHorasLancamentos>
    {

        public AutoMapperRelatorioHorasLancamentos()
        {

        }

        public ICollection<RelatorioHorasLancamentos> Mapear(ICollection<HorasLancamentoViewModel> dados)
        {
            Collection<RelatorioHorasLancamentos> lista = new Collection<RelatorioHorasLancamentos>();
            foreach (HorasLancamentoViewModel source in dados)
            {
                RelatorioHorasLancamentos destination = new RelatorioHorasLancamentos();
                destination.Atividade = source.Atividade;
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Entrada = source.Entrada;
                destination.Saida = source.Saida;
                lista.Add(destination);
            }
            return lista;
        }

        public RelatorioHorasLancamentos Mapear(HorasLancamentoViewModel dados)
        {
            RelatorioHorasLancamentos destination = new RelatorioHorasLancamentos();
            destination.Atividade = dados.Atividade;
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Entrada = dados.Entrada;
            destination.Saida = dados.Saida;
            return destination;
        }

        public HorasLancamentoViewModel Mapear(RelatorioHorasLancamentos dados)
        {
            HorasLancamentoViewModel destination = new HorasLancamentoViewModel();
            destination.Atividade = dados.Atividade;
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Entrada = dados.Entrada;
            destination.Saida = dados.Saida;
            return destination;
        }

        public ICollection<HorasLancamentoViewModel> Mapear(ICollection<RelatorioHorasLancamentos> dados)
        {
            Collection<HorasLancamentoViewModel> lista = new Collection<HorasLancamentoViewModel>();
            foreach (RelatorioHorasLancamentos source in dados)
            {
                HorasLancamentoViewModel destination = new HorasLancamentoViewModel();
                destination.Atividade = source.Atividade;
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Entrada = source.Entrada;
                destination.Saida = source.Saida;
                lista.Add(destination);
            }
            return lista;
        }
    }
}