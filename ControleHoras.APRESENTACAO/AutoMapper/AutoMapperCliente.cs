using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperCliente : IAutoMapper<ClienteViewModel, Cliente>
    {
        public ICollection<Cliente> Mapear(ICollection<ClienteViewModel> dados)
        {
            Collection<Cliente> lista = new Collection<Cliente>();
            if (dados != null && dados.Count > 0)
            {
                foreach (ClienteViewModel source in dados)
                    lista.Add(new Cliente()
                    {
                        Ativo = source.Ativo,
                        ClienteID = source.ClienteID,
                        CNPJ = source.CNPJ,
                        Nome = source.Nome
                    });
            }
            return lista;
        }

        public Cliente Mapear(ClienteViewModel dados)
        {
            return new Cliente()
            {
                Ativo = dados.Ativo,
                ClienteID = dados.ClienteID,
                CNPJ = dados.CNPJ,
                Nome = dados.Nome
            };
        }

        public ClienteViewModel Mapear(Cliente dados)
        {
            return new ClienteViewModel()
            {
                Ativo = dados.Ativo,
                ClienteID = dados.ClienteID,
                CNPJ = dados.CNPJ,
                Nome = dados.Nome
            };
        }

        public ICollection<ClienteViewModel> Mapear(ICollection<Cliente> dados)
        {
            Collection<ClienteViewModel> lista = new Collection<ClienteViewModel>();
            if (dados != null && dados.Count > 0)
            {
                foreach (Cliente source in dados)
                    lista.Add(new ClienteViewModel()
                    {
                        Ativo = source.Ativo,
                        ClienteID = source.ClienteID,
                        CNPJ = source.CNPJ,
                        Nome = source.Nome
                    });
            }
            return lista;
        }

    }
}