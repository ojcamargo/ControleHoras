using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperLancamento : IAutoMapper<LancamentoViewModel, Lancamento>
    {
        private readonly AutoMapperContrato _contratoMapper;
        private readonly AutoMapperProfissional _profissionalMapper;

        public AutoMapperLancamento()
        {
            _contratoMapper = new AutoMapperContrato();
            _profissionalMapper = new AutoMapperProfissional();
        }

        public ICollection<Lancamento> Mapear(ICollection<LancamentoViewModel> dados)
        {
            Collection<Lancamento> lista = new Collection<Lancamento>();
            foreach (LancamentoViewModel source in dados)
                lista.Add(new Lancamento()
                {
                    Atividade = source.Atividade,
                    ContratoID = source.ContratoID,
                    HorarioEntrada = source.HorarioEntrada,
                    HorarioSaida = source.HorarioSaida,
                    LancamentoID = source.LancamentoID,
                    LocalValidado = source.LocalValidado,
                    ProfissionalID= source.ProfissionalID,
                    Observacao = source.Observacao
                });
            return lista;
        }

        public Lancamento Mapear(LancamentoViewModel dados)
        {
            return new Lancamento()
            {
                Atividade = dados.Atividade,
                ContratoID = dados.ContratoID,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                LancamentoID = dados.LancamentoID,
                LocalValidado = dados.LocalValidado,
                ProfissionalID = dados.ProfissionalID,
                Observacao = dados.Observacao
            };
        }

        public LancamentoViewModel Mapear(Lancamento dados)
        {
            if (dados != null)
            {
                return new LancamentoViewModel()
                {
                    Atividade = dados.Atividade,
                    ContratoID = dados.ContratoID,
                    HorarioEntrada = dados.HorarioEntrada,
                    HorarioSaida = dados.HorarioSaida,
                    LancamentoID = dados.LancamentoID,
                    LocalValidado = dados.LocalValidado,
                    ProfissionalID = dados.ProfissionalID,
                    PermitirEntrada = dados.PermitirEntrada,
                    PermitirSaida = dados.PermitirSaida,
                    Observacao = dados.Observacao,
                    Profissional = _profissionalMapper.Mapear(dados.Profissional),
                    Contrato = _contratoMapper.Mapear(dados.Contrato)
                };
            }
            else
            {
                return null;
            }
        }

        public ICollection<LancamentoViewModel> Mapear(ICollection<Lancamento> dados)
        {
            Collection<LancamentoViewModel> lista = new Collection<LancamentoViewModel>();
            foreach (Lancamento source in dados)
                lista.Add(new LancamentoViewModel()
                {
                    Atividade = source.Atividade,
                    ContratoID = source.ContratoID,
                    HorarioEntrada = source.HorarioEntrada,
                    HorarioSaida = source.HorarioSaida,
                    LancamentoID = source.LancamentoID,
                    LocalValidado = source.LocalValidado,
                    ProfissionalID = source.ProfissionalID,
                    Observacao = source.Observacao
                });
            return lista;
        }
    }

    public class AutoMapperLancamentoEdicao : IAutoMapper<LancamentoEdicaoViewModel, Lancamento>
    {
        public ICollection<Lancamento> Mapear(ICollection<LancamentoEdicaoViewModel> dados)
        {
            return null;
        }

        public Lancamento Mapear(LancamentoEdicaoViewModel dados)
        {
            return new Lancamento()
            {
                Atividade = dados.Atividade,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                LancamentoID = dados.LancamentoID,
                Observacao = dados.Observacao,
                Pendente = dados.Pendente
            };
        }

        public LancamentoEdicaoViewModel Mapear(Lancamento dados)
        {
            return null;
        }

        public ICollection<LancamentoEdicaoViewModel> Mapear(ICollection<Lancamento> dados)
        {
            Collection<LancamentoEdicaoViewModel> lista = new Collection<LancamentoEdicaoViewModel>();
            if (dados != null && dados.Count > 0)
            {
                foreach (Lancamento source in dados)
                    lista.Add(new LancamentoEdicaoViewModel()
                    {
                        Atividade = source.Atividade,
                        HorarioEntrada = source.HorarioEntrada,
                        HorarioSaida = source.HorarioSaida,
                        LancamentoID = source.LancamentoID,
                        Contrato = source.Contrato.DescricaoCompleta,
                        Observacao = source.Observacao,
                        Pendente = source.Pendente
                    });
            }
            return lista;
        }
    }
}