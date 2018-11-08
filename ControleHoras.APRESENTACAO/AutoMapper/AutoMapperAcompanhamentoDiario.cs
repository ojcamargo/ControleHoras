
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models.Monitoramento.Resultado;
using ControleHoras.DATA.Context.Custom;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperAcompanhamentoDiario : IAutoMapper<AcompanhamentoDiarioViewModel, AcompanhamentoDiario>
    {
        public ICollection<AcompanhamentoDiario> Mapear(ICollection<AcompanhamentoDiarioViewModel> dados)
        {
            Collection<AcompanhamentoDiario> lista = new Collection<AcompanhamentoDiario>();
            foreach (AcompanhamentoDiarioViewModel source in dados)
            {
                AcompanhamentoDiario destination = new AcompanhamentoDiario();
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Profissional = source.Profissional;
                destination.Situacao = source.Situacao;
                destination.HoraEntrada = source.HoraEntrada;
                lista.Add(destination);
            }
            return lista;
        }

        public AcompanhamentoDiario Mapear(AcompanhamentoDiarioViewModel dados)
        {
            AcompanhamentoDiario destination = new AcompanhamentoDiario();
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Profissional = dados.Profissional;
            destination.Situacao = dados.Situacao;
            destination.HoraEntrada = dados.HoraEntrada;
            return destination;
        }

        public AcompanhamentoDiarioViewModel Mapear(AcompanhamentoDiario dados)
        {
            AcompanhamentoDiarioViewModel destination = new AcompanhamentoDiarioViewModel();
            destination.Cliente = dados.Cliente;
            destination.Contrato = dados.Contrato;
            destination.Profissional = dados.Profissional;
            destination.Situacao = dados.Situacao;
            destination.HoraEntrada = dados.HoraEntrada;
            return destination;
        }

        public ICollection<AcompanhamentoDiarioViewModel> Mapear(ICollection<AcompanhamentoDiario> dados)
        {
            Collection<AcompanhamentoDiarioViewModel> lista = new Collection<AcompanhamentoDiarioViewModel>();
            foreach (AcompanhamentoDiario source in dados)
            {
                AcompanhamentoDiarioViewModel destination = new AcompanhamentoDiarioViewModel();
                destination.Cliente = source.Cliente;
                destination.Contrato = source.Contrato;
                destination.Profissional = source.Profissional;
                destination.Situacao = source.Situacao;
                destination.HoraEntrada = source.HoraEntrada;
                lista.Add(destination);
            }
            return lista;
        }
    }
}