using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperUsuario : IAutoMapper<UsuarioViewModel, Usuario>
    {
        public ICollection<UsuarioViewModel> Mapear(ICollection<Usuario> dados)
        {
            Collection<UsuarioViewModel> lista = new Collection<UsuarioViewModel>();
            foreach (Usuario source in dados)
                lista.Add(new UsuarioViewModel()
                {
                    Adm = source.Adm.HasValue ? source.Adm.Value : false,
                    ClienteID = source.ClienteID,
                    Login = source.Login,
                    ProfissionalID = source.ProfissionalID,
                    UsuarioID = source.UsuarioID,
                    Cliente = source.Cliente == null ? null : new ClienteViewModel()
                    {
                        Ativo = source.Cliente.Ativo,
                        ClienteID = source.Cliente.ClienteID,
                        CNPJ = source.Cliente.CNPJ,
                        Nome = source.Cliente.Nome,
                    },
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
        
        public Usuario Mapear(UsuarioViewModel dados)
        {
            return new Usuario()
            {
                Adm = dados.Adm,
                ClienteID = dados.ClienteID,
                Login = dados.Login,
                ProfissionalID = dados.ProfissionalID,
                UsuarioID = dados.UsuarioID,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                },
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

        public UsuarioViewModel Mapear(Usuario dados)
        {
            if (dados != null)
            {
                return new UsuarioViewModel()
                {
                    Adm = dados.Adm.HasValue ? dados.Adm.Value : false,
                    ClienteID = dados.ClienteID,
                    Login = dados.Login,
                    ProfissionalID = dados.ProfissionalID,
                    UsuarioID = dados.UsuarioID,
                    Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                    {
                        Ativo = dados.Cliente.Ativo,
                        ClienteID = dados.Cliente.ClienteID,
                        CNPJ = dados.Cliente.CNPJ,
                        Nome = dados.Cliente.Nome,
                    },
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
            else
                return null;
        }

        public ICollection<Usuario> Mapear(ICollection<UsuarioViewModel> dados)
        {
            Collection<Usuario> lista = new Collection<Usuario>();
            foreach (UsuarioViewModel source in dados)
                lista.Add(new Usuario()
                {
                    Adm = source.Adm,
                    ClienteID = source.ClienteID,
                    Login = source.Login,
                    ProfissionalID = source.ProfissionalID,
                    UsuarioID = source.UsuarioID,
                    Cliente = source.Cliente == null ? null : new Cliente()
                    {
                        Ativo = source.Cliente.Ativo,
                        ClienteID = source.Cliente.ClienteID,
                        CNPJ = source.Cliente.CNPJ,
                        Nome = source.Cliente.Nome,
                    },
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
    }

    public class AutoMapperUsuarioCriacao : IAutoMapper<UsuarioCriacaoViewModel, Usuario>
    {
        public ICollection<UsuarioCriacaoViewModel> Mapear(ICollection<Usuario> dados)
        {
            throw new NotImplementedException("Não se aplica para cadastro");
        }

        public Usuario Mapear(UsuarioCriacaoViewModel dados)
        {
            return new Usuario()
            {
                Adm = dados.Adm,
                ClienteID = dados.ClienteID,
                Login = dados.Login,
                ProfissionalID = dados.ProfissionalID,
                Senha = dados.Senha,
                UsuarioID = dados.UsuarioID,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                },
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

        public UsuarioCriacaoViewModel Mapear(Usuario dados)
        {
            return new UsuarioCriacaoViewModel()
            {
                Adm = dados.Adm.HasValue ? dados.Adm.Value : false,
                ClienteID = dados.ClienteID,
                Login = dados.Login,
                ProfissionalID = dados.ProfissionalID,
                Senha = dados.Senha,
                UsuarioID = dados.UsuarioID,
                Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                },
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

        public ICollection<Usuario> Mapear(ICollection<UsuarioCriacaoViewModel> dados)
        {
            throw new NotImplementedException("Não se aplica para cadastro");
        }
    }

    public class AutoMapperUsuarioSenha : IAutoMapper<UsuarioSenhaViewModel, Usuario>
    {
        public ICollection<UsuarioSenhaViewModel> Mapear(ICollection<Usuario> dados)
        {
            throw new NotImplementedException("Não se aplica para cadastro");
        }

        public Usuario Mapear(UsuarioSenhaViewModel dados)
        {
            return new Usuario()
            {
                Adm = dados.Adm,
                ClienteID = dados.ClienteID,
                Login = dados.Login,
                ProfissionalID = dados.ProfissionalID,
                Senha = dados.Senha,
                UsuarioID = dados.UsuarioID,
                Cliente = dados.Cliente == null ? null : new Cliente()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                },
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

        public UsuarioSenhaViewModel Mapear(Usuario dados)
        {
            return new UsuarioSenhaViewModel()
            {
                Adm = dados.Adm.HasValue ? dados.Adm.Value : false,
                ClienteID = dados.ClienteID,
                Login = dados.Login,
                ProfissionalID = dados.ProfissionalID,
                Senha = dados.Senha,
                UsuarioID = dados.UsuarioID,
                Cliente = dados.Cliente == null ? null : new ClienteViewModel()
                {
                    Ativo = dados.Cliente.Ativo,
                    ClienteID = dados.Cliente.ClienteID,
                    CNPJ = dados.Cliente.CNPJ,
                    Nome = dados.Cliente.Nome,
                },
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

        public ICollection<Usuario> Mapear(ICollection<UsuarioSenhaViewModel> dados)
        {
            throw new NotImplementedException("Não se aplica para cadastro");
        }

    }

}