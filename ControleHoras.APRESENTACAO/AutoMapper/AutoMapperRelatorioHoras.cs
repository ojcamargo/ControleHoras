using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models.Relatorios.Resultado;
using ControleHoras.DATA.Context.Custom;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperRelatorioHoras : IAutoMapper<HorasViewModel, RelatorioHoras>
    {

        private readonly AutoMapperRelatorioHorasLancamentos _lancamentosMapper;

        public AutoMapperRelatorioHoras()
        {
            _lancamentosMapper = new AutoMapperRelatorioHorasLancamentos();
        }

        public ICollection<RelatorioHoras> Mapear(ICollection<HorasViewModel> dados)
        {
            Collection<RelatorioHoras> lista = new Collection<RelatorioHoras>();
            foreach (HorasViewModel source in dados)
            {
                RelatorioHoras destination = new RelatorioHoras();
                destination.DataEmissao = source.DataEmissao;
                destination.Periodo = source.Periodo;
                destination.Profissional = source.Profissional;
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

        public RelatorioHoras Mapear(HorasViewModel dados)
        {
            RelatorioHoras destination = new RelatorioHoras();
            destination.DataEmissao = dados.DataEmissao;
            destination.Periodo = dados.Periodo;
            destination.Profissional = dados.Profissional;
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public HorasViewModel Mapear(RelatorioHoras dados)
        {
            HorasViewModel destination = new HorasViewModel();
            destination.DataEmissao = dados.DataEmissao;
            destination.Periodo = dados.Periodo;
            destination.Profissional = dados.Profissional;
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public ICollection<HorasViewModel> Mapear(ICollection<RelatorioHoras> dados)
        {
            Collection<HorasViewModel> lista = new Collection<HorasViewModel>();
            foreach (RelatorioHoras source in dados)
            {
                HorasViewModel destination = new HorasViewModel();
                destination.DataEmissao = source.DataEmissao;
                destination.Periodo = source.Periodo;
                destination.Profissional = source.Profissional;
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

    }
}