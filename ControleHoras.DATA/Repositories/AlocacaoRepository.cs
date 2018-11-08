using System;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ControleHoras.DATA.Repositories
{
    public class AlocacaoRepository : BaseRepository<Alocacao>, IAlocacaoRepository
    {
        /// <summary>
        /// Verificar profissional esta alocado no projeto
        /// </summary>
        /// <param name="alocacao"></param>
        /// <returns></returns>
        public bool ProfissionalAlocado(Alocacao alocacao)
        {
            return Db.Alocacao.Where(x => x.ContratoID == alocacao.ContratoID && 
                                        x.ProfissionalID == alocacao.ProfissionalID).Count() > 0;
        }

        /// <summary>
        /// Listar contratos disponiveis para alocação
        /// </summary>
        /// <returns></returns>
        public ICollection<Contrato> ListarContratos()
        {
            List<Contrato> contratosAtivos = (from con in Db.Contrato
                                                join al in Db.Alocacao 
                                                on con.ContratoID equals al.ContratoID
                                                select con).Distinct().ToList();
            if(contratosAtivos != null && contratosAtivos.Count > 0)
            {
                contratosAtivos.ForEach(x => x.Cliente = Db.Cliente.Where(c => c.ClienteID == x.ClienteID).FirstOrDefault());
            }
            return contratosAtivos;
        }

        /// <summary>
        /// Listar contratos por profissionais
        /// </summary>
        /// <param name="profissionalId"></param>
        /// <returns></returns>
        public ICollection<Contrato> ListarContratos(int profissionalId)
        {
            List<Contrato> contratosAtivos = (from con in Db.Contrato
                                              join al in Db.Alocacao
                                              on con.ContratoID equals al.ContratoID
                                              where al.ProfissionalID == profissionalId
                                              select con).ToList();
            
            return contratosAtivos;
        }

        /// <summary>
        /// Listar profissionais por contrato
        /// </summary>
        /// <param name="contratoId"></param>
        /// <returns></returns>
        public ICollection<Profissional> ListarProfissionais(int contratoId)
        {
            List<Profissional> profissionaisAlocados = (from p in Db.Profissional
                                                        join al in Db.Alocacao
                                                        on p.ProfissionalID equals al.ProfissionalID
                                                        where al.ContratoID == contratoId
                                                        select p).ToList();
           
            return profissionaisAlocados;
        }

        /// <summary>
        /// Remover todas as alocações do contrato
        /// </summary>
        /// <param name="contratoId"></param>
        public void RemoverTodos(int contratoId)
        {
            List<Alocacao> profissionaisAlocados = null;
            try
            {
                profissionaisAlocados = (from p in Db.Alocacao where p.ContratoID == contratoId select p).ToList();
                if (profissionaisAlocados != null)
                {
                    foreach (Alocacao alocacao in profissionaisAlocados)
                    {
                        this.Remover(alocacao);
                    }
                }
            }
            finally
            {
                profissionaisAlocados = null;
            }
        }


    }
}
