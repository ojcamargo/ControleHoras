using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperProfissional : IAutoMapper<ProfissionalViewModel, Profissional>
    {
        public ICollection<Profissional> Mapear(ICollection<ProfissionalViewModel> dados)
        {
            Collection<Profissional> lista = new Collection<Profissional>();
            if (dados != null && dados.Count > 0)
            {
                foreach (ProfissionalViewModel source in dados)
                    lista.Add(new Profissional()
                    {
                        Ativo = source.Ativo,
                        HorarioEntrada = source.HorarioEntrada,
                        HorarioSaida = source.HorarioSaida,
                        ModalidadeApuracao = source.ModalidadeApuracao,
                        Nome = source.Nome,
                        ProfissionalID = source.ProfissionalID,
                        ValorHora = source.ValorHora,
                        ValorMensal = source.ValorMensal,
                        Regime = source.Regime,
                        FeriasInicio = source.FeriasInicio,
                        FeriasTermino = source.FeriasTermino
                    });
            }
            return lista;
        }

        public Profissional Mapear(ProfissionalViewModel dados)
        {
            return new Profissional()
            {
                Ativo = dados.Ativo,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                ModalidadeApuracao = dados.ModalidadeApuracao,
                Nome = dados.Nome,
                ProfissionalID = dados.ProfissionalID,
                ValorHora = dados.ValorHora,
                ValorMensal = dados.ValorMensal,
                Regime = dados.Regime,
                FeriasInicio = dados.FeriasInicio,
                FeriasTermino = dados.FeriasTermino

            };
        }

        public ProfissionalViewModel Mapear(Profissional dados)
        {
            return new ProfissionalViewModel()
            {
                Ativo = dados.Ativo,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                ModalidadeApuracao = dados.ModalidadeApuracao,
                Nome = dados.Nome,
                ProfissionalID = dados.ProfissionalID,
                ValorHora = dados.ValorHora,
                ValorMensal = dados.ValorMensal,
                Regime = dados.Regime,
                FeriasInicio = dados.FeriasInicio,
                FeriasTermino = dados.FeriasTermino
            };
        }

        public ICollection<ProfissionalViewModel> Mapear(ICollection<Profissional> dados)
        {
            Collection<ProfissionalViewModel> lista = new Collection<ProfissionalViewModel>();
            if (dados != null && dados.Count > 0)
            {
                foreach (Profissional source in dados)
                    lista.Add(new ProfissionalViewModel()
                    {
                        Ativo = source.Ativo,
                        HorarioEntrada = source.HorarioEntrada,
                        HorarioSaida = source.HorarioSaida,
                        ModalidadeApuracao = source.ModalidadeApuracao,
                        Nome = source.Nome,
                        ProfissionalID = source.ProfissionalID,
                        ValorHora = source.ValorHora,
                        ValorMensal = source.ValorMensal,
                        Regime = source.Regime,
                        FeriasInicio = source.FeriasInicio,
                        FeriasTermino = source.FeriasTermino
                    });
            }
            return lista;
        }
    }
}