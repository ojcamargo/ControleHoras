using ControleHoras.DATA.Context.Custom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models.Demonstrativos.Resultado;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperDemonstrativoLancamentos : IAutoMapper<HorasLancamentoViewModel, DemonstrativoLancamentos>
    {
        private readonly AutoMapperContrato _contratoMapper;

        public AutoMapperDemonstrativoLancamentos()
        {
            _contratoMapper = new AutoMapperContrato();
        }

        public ICollection<DemonstrativoLancamentos> Mapear(ICollection<HorasLancamentoViewModel> dados)
        {
            Collection<DemonstrativoLancamentos> lista = new Collection<DemonstrativoLancamentos>();
            foreach (HorasLancamentoViewModel source in dados)
            {
                DemonstrativoLancamentos destination = new DemonstrativoLancamentos();
                destination.ContratoID = source.ContratoID;
                destination.QtdHoras = source.QtdHoras;
                destination.ValorPorContrato = source.ValorPorContrato;
                destination.ValorBase = source.ValorBase;
                destination.QtdDiasTrabalhados = source.QtdDiasTrabalhados;
                if (source.Contrato != null)
                    destination.Contrato = _contratoMapper.Mapear(source.Contrato);
                lista.Add(destination);
            }
            return lista;
        }

        public DemonstrativoLancamentos Mapear(HorasLancamentoViewModel dados)
        {
            DemonstrativoLancamentos destination = new DemonstrativoLancamentos();
            destination.ContratoID = dados.ContratoID;
            destination.QtdHoras = dados.QtdHoras;
            destination.ValorPorContrato = dados.ValorPorContrato;
            destination.QtdDiasTrabalhados = dados.QtdDiasTrabalhados;
            destination.ValorBase = dados.ValorBase;
            if (dados.Contrato != null)
                destination.Contrato = _contratoMapper.Mapear(dados.Contrato);
            return destination;
        }

        public HorasLancamentoViewModel Mapear(DemonstrativoLancamentos dados)
        {
            HorasLancamentoViewModel destination = new HorasLancamentoViewModel();
            destination.ContratoID = dados.ContratoID;
            destination.QtdHoras = dados.QtdHoras;
            destination.ValorPorContrato = dados.ValorPorContrato;
            destination.QtdDiasTrabalhados = dados.QtdDiasTrabalhados;
            destination.ValorBase = dados.ValorBase;
            if (dados.Contrato != null)
                destination.Contrato = _contratoMapper.Mapear(dados.Contrato);
            return destination;
        }

        public ICollection<HorasLancamentoViewModel> Mapear(ICollection<DemonstrativoLancamentos> dados)
        {
            Collection<HorasLancamentoViewModel> lista = new Collection<HorasLancamentoViewModel>();
            foreach (DemonstrativoLancamentos source in dados)
            {
                HorasLancamentoViewModel destination = new HorasLancamentoViewModel();
                destination.ContratoID = source.ContratoID;
                destination.QtdHoras = source.QtdHoras;
                destination.ValorPorContrato = source.ValorPorContrato;
                destination.ValorBase = source.ValorBase;
                destination.QtdDiasTrabalhados = source.QtdDiasTrabalhados;
                if (source.Contrato != null)
                    destination.Contrato = _contratoMapper.Mapear(source.Contrato);
                lista.Add(destination);
            }
            return lista;
        }
    }
}