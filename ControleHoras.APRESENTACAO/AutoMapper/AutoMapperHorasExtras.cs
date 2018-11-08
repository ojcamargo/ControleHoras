using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperHorasExtras : IAutoMapper<HorasExtrasViewModel, HorasExtras>
    {
        private readonly AutoMapperContrato _contratoMapper;
        private readonly AutoMapperProfissional _profissionalMapper;

        public AutoMapperHorasExtras()
        {
            _contratoMapper = new AutoMapperContrato();
            _profissionalMapper = new AutoMapperProfissional();
        }

        public ICollection<HorasExtras> Mapear(ICollection<HorasExtrasViewModel> dados)
        {
            Collection<HorasExtras> lista = new Collection<HorasExtras>();
            foreach (HorasExtrasViewModel source in dados)
            {
                HorasExtras objeto = new HorasExtras()
                {
                    AprovacaoID = source.AprovacaoID,
                    ContratoID = source.ContratoID,
                    DataFinal = source.DataFinal,
                    DataInicial = source.DataInicial,
                    ProfissionalID = source.ProfissionalID,
                    Pendente = source.Pendente
                };
                if (source.Contrato != null)
                    objeto.Contrato = _contratoMapper.Mapear(source.Contrato);
                if (source.Profissional != null)
                    objeto.Profissional = _profissionalMapper.Mapear(source.Profissional);
                lista.Add(objeto);
            }
            return lista;
        }

        public HorasExtras Mapear(HorasExtrasViewModel dados)
        {
            HorasExtras objeto = new HorasExtras()
            {
                AprovacaoID = dados.AprovacaoID,
                ContratoID = dados.ContratoID,
                DataFinal = dados.DataFinal,
                DataInicial = dados.DataInicial,
                ProfissionalID = dados.ProfissionalID,
                Pendente = dados.Pendente
            };
            if (dados.Contrato != null)
                objeto.Contrato = _contratoMapper.Mapear(dados.Contrato);
            if (dados.Profissional != null)
                objeto.Profissional = _profissionalMapper.Mapear(dados.Profissional);
            return objeto;
        }

        public HorasExtrasViewModel Mapear(HorasExtras dados)
        {
            HorasExtrasViewModel objeto = new HorasExtrasViewModel()
            {
                AprovacaoID = dados.AprovacaoID,
                ContratoID = dados.ContratoID,
                DataFinal = dados.DataFinal,
                DataInicial = dados.DataInicial,
                ProfissionalID = dados.ProfissionalID,
                Pendente = dados.Pendente
            };
            if (dados.Contrato != null)
                objeto.Contrato = _contratoMapper.Mapear(dados.Contrato);
            if (dados.Profissional != null)
                objeto.Profissional = _profissionalMapper.Mapear(dados.Profissional);
            return objeto;
        }

        public ICollection<HorasExtrasViewModel> Mapear(ICollection<HorasExtras> dados)
        {
            Collection<HorasExtrasViewModel> lista = new Collection<HorasExtrasViewModel>();
            foreach (HorasExtras source in dados)
            {
                HorasExtrasViewModel objeto = new HorasExtrasViewModel()
                {
                    AprovacaoID = source.AprovacaoID,
                    ContratoID = source.ContratoID,
                    DataFinal = source.DataFinal,
                    DataInicial = source.DataInicial,
                    ProfissionalID = source.ProfissionalID,
                    Pendente = source.Pendente
                };
                if (source.Contrato != null)
                    objeto.Contrato = _contratoMapper.Mapear(source.Contrato);
                if (source.Profissional != null)
                    objeto.Profissional = _profissionalMapper.Mapear(source.Profissional);
                lista.Add(objeto);
            }
            return lista;
        }
    }
}