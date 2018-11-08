using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperClienteIp : IAutoMapper<ClienteIpViewModel, ClienteIp>
    {
        public ICollection<ClienteIp> Mapear(ICollection<ClienteIpViewModel> dados)
        {
            Collection<ClienteIp> lista = new Collection<ClienteIp>();
            foreach (ClienteIpViewModel source in dados)
                lista.Add(new ClienteIp()
                {
                    ClienteIpID = source.ClienteIpID,
                    ClienteID = source.ClienteID,
                    Ip = source.Ip
                });
            return lista;
        }

        public ClienteIp Mapear(ClienteIpViewModel dados)
        {
            return new ClienteIp()
            {
                ClienteIpID = dados.ClienteIpID,
                Ip = dados.Ip,
                ClienteID = dados.ClienteID,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome
                }
            };
        }

        public ClienteIpViewModel Mapear(ClienteIp dados)
        {
            return new ClienteIpViewModel()
            {
                ClienteIpID = dados.ClienteIpID,
                Ip = dados.Ip,
                ClienteID = dados.ClienteID,
                Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome
                }
            };
        }

        public ICollection<ClienteIpViewModel> Mapear(ICollection<ClienteIp> dados)
        {
            Collection<ClienteIpViewModel> lista = new Collection<ClienteIpViewModel>();
            foreach (ClienteIp source in dados)
                lista.Add(new ClienteIpViewModel()
                {
                    ClienteIpID = source.ClienteIpID,
                    ClienteID = source.ClienteID,
                    Ip = source.Ip
                });
            return lista;
        }

    }
}