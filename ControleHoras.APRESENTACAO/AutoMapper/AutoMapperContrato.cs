using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperContrato : IAutoMapper<ContratoViewModel, Contrato>
    {
        public ICollection<Contrato> Mapear(ICollection<ContratoViewModel> dados)
        {
            Collection<Contrato> lista = new Collection<Contrato>();
            if (dados != null && dados.Count > 0)
            {
                foreach (ContratoViewModel source in dados)
                    lista.Add(new Contrato()
                    {
                        ApuracaoHoraExtra = source.ApuracaoHoraExtra,
                        Ativo = source.Ativo,
                        ClienteID = source.ClienteID,
                        ContratoID = source.ContratoID,
                        DataCadastro = source.DataCadastro,
                        DataFim = source.DataFim,
                        DataInicio = source.DataInicio,
                        Descricao = source.Descricao,
                        HorarioEntrada = source.HorarioEntrada,
                        HorarioSaida = source.HorarioSaida,
                        IntervaloInicio = source.IntervaloInicio,
                        IntervaloFim = source.IntervaloFim,
                        ModalidadeApuracao = source.ModalidadeApuracao,
                        ModalidadeContrato = source.ModalidadeContrato,
                        NumeroReferencia = source.NumeroReferencia,
                        QtdHorasMes = source.QtdHorasMes,
                        ValidarLocalizacao = source.ValidarLocalizacao,
                        ValorHora = source.ValorHora,
                        ValorHoraExtra = source.ValorHoraExtra,
                        Cliente = source.Cliente == null ? null : new Cliente()
                        {
                            Ativo = source.Cliente.Ativo,
                            ClienteID = source.Cliente.ClienteID,
                            CNPJ = source.Cliente.CNPJ,
                            Nome = source.Cliente.Nome,
                        }
                    });
            }
            return lista;
        }

        public Contrato Mapear(ContratoViewModel dados)
        {
            return new Contrato()
            {
                ApuracaoHoraExtra = dados.ApuracaoHoraExtra,
                Ativo = dados.Ativo,
                ClienteID = dados.ClienteID,
                ContratoID = dados.ContratoID,
                DataCadastro = dados.DataCadastro,
                DataFim = dados.DataFim,
                DataInicio = dados.DataInicio,
                Descricao = dados.Descricao,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                IntervaloInicio = dados.IntervaloInicio,
                IntervaloFim = dados.IntervaloFim,
                ModalidadeApuracao = dados.ModalidadeApuracao,
                ModalidadeContrato = dados.ModalidadeContrato,
                NumeroReferencia = dados.NumeroReferencia,
                QtdHorasMes = dados.QtdHorasMes,
                ValidarLocalizacao = dados.ValidarLocalizacao,
                ValorHora = dados.ValorHora,
                ValorHoraExtra = dados.ValorHoraExtra,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                }
            };
        }

        public ContratoViewModel Mapear(Contrato dados)
        {
            return new ContratoViewModel()
            {
                ApuracaoHoraExtra = dados.ApuracaoHoraExtra,
                Ativo = dados.Ativo,
                ClienteID = dados.ClienteID,
                ContratoID = dados.ContratoID,
                DataCadastro = dados.DataCadastro,
                DataFim = dados.DataFim,
                DataInicio = dados.DataInicio,
                Descricao = dados.Descricao,
                HorarioEntrada = dados.HorarioEntrada,
                HorarioSaida = dados.HorarioSaida,
                IntervaloInicio = dados.IntervaloInicio,
                IntervaloFim = dados.IntervaloFim,
                ModalidadeApuracao = dados.ModalidadeApuracao,
                ModalidadeContrato = dados.ModalidadeContrato,
                NumeroReferencia = dados.NumeroReferencia,
                QtdHorasMes = dados.QtdHorasMes,
                ValidarLocalizacao = dados.ValidarLocalizacao.HasValue ? dados.ValidarLocalizacao.Value : false,
                ValorHora = dados.ValorHora,
                ValorHoraExtra = dados.ValorHoraExtra,
                Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                }
            };
        }

        public ICollection<ContratoViewModel> Mapear(ICollection<Contrato> dados)
        {
            Collection<ContratoViewModel> lista = new Collection<ContratoViewModel>();
            if (dados != null && dados.Count > 0)
            {
                foreach (Contrato source in dados)
                    lista.Add(new ContratoViewModel()
                    {
                        ApuracaoHoraExtra = source.ApuracaoHoraExtra,
                        Ativo = source.Ativo,
                        ClienteID = source.ClienteID,
                        ContratoID = source.ContratoID,
                        DataCadastro = source.DataCadastro,
                        DataFim = source.DataFim,
                        DataInicio = source.DataInicio,
                        Descricao = source.Descricao,
                        HorarioEntrada = source.HorarioEntrada,
                        HorarioSaida = source.HorarioSaida,
                        IntervaloInicio = source.IntervaloInicio,
                        IntervaloFim = source.IntervaloFim,
                        ModalidadeApuracao = source.ModalidadeApuracao,
                        ModalidadeContrato = source.ModalidadeContrato,
                        NumeroReferencia = source.NumeroReferencia,
                        QtdHorasMes = source.QtdHorasMes,
                        ValidarLocalizacao = source.ValidarLocalizacao.HasValue ? source.ValidarLocalizacao.Value : false,
                        ValorHora = source.ValorHora,
                        ValorHoraExtra = source.ValorHoraExtra,
                        Cliente = source.Cliente == null ? null : new ClienteViewModel()
                        {
                            Ativo = source.Cliente.Ativo,
                            ClienteID = source.Cliente.ClienteID,
                            CNPJ = source.Cliente.CNPJ,
                            Nome = source.Cliente.Nome,
                        }
                    });
            }
            return lista;
        }
    }
}