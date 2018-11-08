using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using ControleHoras.DATA.Repositories;

namespace ControleHoras.DATA.Services
{
    public class AlocacaoService : BaseService<Alocacao>, IAlocacaoService
    {
        private readonly IAlocacaoRepository _repository;
        public AlocacaoService(IAlocacaoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Listar contratos disponiveis para alocação
        /// </summary>
        /// <returns></returns>
        public ICollection<Contrato> ListarContratos()
        {
            ICollection<Contrato> lista = _repository.ListarContratos();
            return lista;
        }

        /// <summary>
        /// Listar contratos por profissional
        /// </summary>
        /// <param name="profissionalId"></param>
        /// <returns></returns>
        public ICollection<Contrato> ListarContratos(int profissionalId)
        {
            return _repository.ListarContratos(profissionalId);
        }

        /// <summary>
        /// Listar profissionais por contrato
        /// </summary>
        /// <param name="contratoId"></param>
        /// <returns></returns>
        public ICollection<Profissional> ListarProfissionais(int contratoId)
        {
            return _repository.ListarProfissionais(contratoId);
        }

        /// <summary>
        /// Verificar se profissional esta alocado no contrato
        /// </summary>
        /// <param name="alocacao"></param>
        /// <returns></returns>
        public bool ProfissionalAlocado(Alocacao alocacao)
        {
            return _repository.ProfissionalAlocado(alocacao);
        }

        /// <summary>
        /// Remover todas as alocações do contrato
        /// </summary>
        /// <param name="contratoId"></param>
        public void RemoverTodos(int contratoId)
        {
            _repository.RemoverTodos(contratoId);
        }
    }
}
