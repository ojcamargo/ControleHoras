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
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override void Incluir(Cliente objeto)
        {
            objeto.Ativo = true;
            base.Incluir(objeto);
        }

        public void Desativar(Cliente objeto)
        {
            objeto.Ativo = false;
            _repository.Atualizar(objeto);
        }

        public void Reativar(Cliente objeto)
        {
            objeto.Ativo = true;
            _repository.Atualizar(objeto);
        }

        public ICollection<Cliente> ListarAtivos()
        {
            return _repository.ListarAtivos();
        }

        public Cliente ConsultarPorIdSemRastreamento(long id)
        {
            return _repository.ConsultarPorIdSemRastreamento(id);
        }
    }
}
