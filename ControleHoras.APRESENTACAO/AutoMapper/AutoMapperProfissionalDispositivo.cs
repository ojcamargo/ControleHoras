using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperProfissionalDispositivo : IAutoMapper<ProfissionalDispositivoViewModel, ProfissionalDispositivo>
    {
        public ICollection<ProfissionalDispositivo> Mapear(ICollection<ProfissionalDispositivoViewModel> dados)
        {
            Collection<ProfissionalDispositivo> lista = new Collection<ProfissionalDispositivo>();
            foreach (ProfissionalDispositivoViewModel source in dados)
                lista.Add(new ProfissionalDispositivo()
                {
                    Imei = source.Imei,
                    ProfissionalDispositivoID = source.ProfissionalDispositivoID,
                    ProfissionalID = source.ProfissionalID,
                    Telefone = source.Telefone,
                    Profissional = source.Profissional == null ? null : new Profissional()
                    {
                        ProfissionalID = source.Profissional.ProfissionalID,
                        Ativo = source.Profissional.Ativo,
                        HorarioEntrada = source.Profissional.HorarioEntrada,
                        HorarioSaida = source.Profissional.HorarioSaida,
                        ModalidadeApuracao = source.Profissional.ModalidadeApuracao,
                        Nome = source.Profissional.Nome,
                        ValorHora = source.Profissional.ValorHora,
                        ValorMensal = source.Profissional.ValorMensal
                    }
                });
            return lista;
        }

        public ProfissionalDispositivo Mapear(ProfissionalDispositivoViewModel dados)
        {
            return new ProfissionalDispositivo()
            {
                Imei = dados.Imei,
                ProfissionalDispositivoID = dados.ProfissionalDispositivoID,
                ProfissionalID = dados.ProfissionalID,
                Telefone = dados.Telefone,
                Profissional = dados.Profissional == null ? null : new Profissional()
                {
                    ProfissionalID = dados.Profissional.ProfissionalID,
                    Ativo = dados.Profissional.Ativo,
                    HorarioEntrada = dados.Profissional.HorarioEntrada,
                    HorarioSaida = dados.Profissional.HorarioSaida,
                    ModalidadeApuracao = dados.Profissional.ModalidadeApuracao,
                    Nome = dados.Profissional.Nome,
                    ValorHora = dados.Profissional.ValorHora,
                    ValorMensal = dados.Profissional.ValorMensal
                }
            };
        }

        public ProfissionalDispositivoViewModel Mapear(ProfissionalDispositivo dados)
        {
            return new ProfissionalDispositivoViewModel()
            {
                Imei = dados.Imei,
                ProfissionalDispositivoID = dados.ProfissionalDispositivoID,
                ProfissionalID = dados.ProfissionalID,
                Telefone = dados.Telefone,
                Profissional = dados.Profissional == null ? null : new ProfissionalViewModel()
                {
                    ProfissionalID = dados.Profissional.ProfissionalID,
                    Ativo = dados.Profissional.Ativo,
                    HorarioEntrada = dados.Profissional.HorarioEntrada,
                    HorarioSaida = dados.Profissional.HorarioSaida,
                    ModalidadeApuracao = dados.Profissional.ModalidadeApuracao,
                    Nome = dados.Profissional.Nome,
                    ValorHora = dados.Profissional.ValorHora,
                    ValorMensal = dados.Profissional.ValorMensal
                }
            };
        }

        public ICollection<ProfissionalDispositivoViewModel> Mapear(ICollection<ProfissionalDispositivo> dados)
        {
            Collection<ProfissionalDispositivoViewModel> lista = new Collection<ProfissionalDispositivoViewModel>();
            foreach (ProfissionalDispositivo source in dados)
                lista.Add(new ProfissionalDispositivoViewModel()
                {
                    Imei = source.Imei,
                    ProfissionalDispositivoID = source.ProfissionalDispositivoID,
                    ProfissionalID = source.ProfissionalID,
                    Telefone = source.Telefone,
                    Profissional = source.Profissional == null ? null : new ProfissionalViewModel()
                    {
                        ProfissionalID = source.Profissional.ProfissionalID,
                        Ativo = source.Profissional.Ativo,
                        HorarioEntrada = source.Profissional.HorarioEntrada,
                        HorarioSaida = source.Profissional.HorarioSaida,
                        ModalidadeApuracao = source.Profissional.ModalidadeApuracao,
                        Nome = source.Profissional.Nome,
                        ValorHora = source.Profissional.ValorHora,
                        ValorMensal = source.Profissional.ValorMensal
                    }
                });
            return lista;
        }
    }
}