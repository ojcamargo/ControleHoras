using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using ControleHoras.APRESENTACAO.Models;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperAlocacao : IAutoMapper<AlocacaoViewModel, Alocacao>
    {
        public ICollection<AlocacaoViewModel> Mapear(ICollection<Alocacao> dados)
        {
            Collection<AlocacaoViewModel> lista = new Collection<AlocacaoViewModel>();
            foreach (Alocacao source in dados)
                lista.Add(new AlocacaoViewModel()
                {
                    ContratoID = source.ContratoID,
                    ProfissionalID = source.ProfissionalID
                });
            return lista;
        }

        public AlocacaoViewModel Mapear(Alocacao dados)
        {
            return new AlocacaoViewModel()
            {
                ContratoID = dados.ContratoID,
                ProfissionalID = dados.ProfissionalID
            };
        }

        public ICollection<Alocacao> Mapear(ICollection<AlocacaoViewModel> dados)
        {
            Collection<Alocacao> lista = new Collection<Alocacao>();
            foreach (AlocacaoViewModel source in dados)
                lista.Add(new Alocacao()
                {
                    ContratoID = source.ContratoID,
                    ProfissionalID = source.ProfissionalID
                });
            return lista;
        }

        public Alocacao Mapear(AlocacaoViewModel dados)
        {
            return new Alocacao()
            {
                ContratoID = dados.ContratoID,
                ProfissionalID = dados.ProfissionalID
            };
        }
    }
    

}