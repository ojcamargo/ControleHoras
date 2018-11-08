using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperClienteLocal : IAutoMapper<ClienteLocalViewModel, ClienteLocal>
    {
        public ICollection<ClienteLocal> Mapear(ICollection<ClienteLocalViewModel> dados)
        {
            Collection<ClienteLocal> lista = new Collection<ClienteLocal>();
            foreach (ClienteLocalViewModel source in dados)
                lista.Add(new ClienteLocal()
                {
                    Bairro = source.Bairro,
                    CEP = source.CEP,
                    Cidade = source.Cidade,
                    ClienteID = source.ClienteID,
                    Complemento = source.Complemento,
                    Latitude = source.Latitude,
                    LocalID = source.LocalID,
                    Logradouro = source.Logradouro,
                    Longitude = source.Longitude,
                    NumeroLogradouro = source.NumeroLogradouro,
                    UF = source.UF,
                    Cliente = source.Cliente == null ? null : new Cliente()
                    {
                        Ativo = source.Cliente.Ativo,
                        ClienteID = source.Cliente.ClienteID,
                        CNPJ = source.Cliente.CNPJ,
                        Nome = source.Cliente.Nome
                    }
                });
            return lista;
        }

        public ClienteLocal Mapear(ClienteLocalViewModel dados)
        {
            return new ClienteLocal()
            {
                Bairro = dados.Bairro,
                CEP = dados.CEP,
                Cidade = dados.Cidade,
                ClienteID = dados.ClienteID,
                Complemento = dados.Complemento,
                Latitude = dados.Latitude,
                LocalID = dados.LocalID,
                Logradouro = dados.Logradouro,
                Longitude = dados.Longitude,
                NumeroLogradouro = dados.NumeroLogradouro,
                UF = dados.UF,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome
                }
            };
        }

        public ClienteLocalViewModel Mapear(ClienteLocal dados)
        {
            return new ClienteLocalViewModel()
            {
                Bairro = dados.Bairro,
                CEP = dados.CEP,
                Cidade = dados.Cidade,
                ClienteID = dados.ClienteID,
                Complemento = dados.Complemento,
                Latitude = dados.Latitude,
                LocalID = dados.LocalID,
                Logradouro = dados.Logradouro,
                Longitude = dados.Longitude,
                NumeroLogradouro = dados.NumeroLogradouro,
                UF = dados.UF,
                Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome
                }
            };
        }

        public ICollection<ClienteLocalViewModel> Mapear(ICollection<ClienteLocal> dados)
        {
            Collection<ClienteLocalViewModel> lista = new Collection<ClienteLocalViewModel>();
            foreach (ClienteLocal source in dados)
                lista.Add(new ClienteLocalViewModel()
                {
                    Bairro = source.Bairro,
                    CEP = source.CEP,
                    Cidade = source.Cidade,
                    ClienteID = source.ClienteID,
                    Complemento = source.Complemento,
                    Latitude = source.Latitude,
                    LocalID = source.LocalID,
                    Logradouro = source.Logradouro,
                    Longitude = source.Longitude,
                    NumeroLogradouro = source.NumeroLogradouro,
                    UF = source.UF,
                    Cliente = source.Cliente == null ? null : new ClienteViewModel()
                    {
                        Ativo = source.Cliente.Ativo,
                        ClienteID = source.Cliente.ClienteID,
                        CNPJ = source.Cliente.CNPJ,
                        Nome = source.Cliente.Nome
                    }
                });
            return lista;
        }
    }
}