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
    public class ProfissionalService : BaseService<Profissional>, IProfissionalService
    {
        private readonly IProfissionalRepository _repository;

        public ProfissionalService(IProfissionalRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override void Incluir(Profissional objeto)
        {
            objeto.Ativo = true;
            base.Incluir(objeto);
        }

        public void Desativar(Profissional objeto)
        {
            objeto.Ativo = false;
            _repository.Atualizar(objeto);
        }

        public ICollection<Profissional> ListarAtivos()
        {
            return _repository.ListarAtivos();
        }

        public void Reativar(Profissional objeto)
        {
            objeto.Ativo = true;
            _repository.Atualizar(objeto);
        }

        public Profissional ConsultarPorIdSemRastreamento(long id)
        {
            return _repository.ConsultarPorIdSemRastreamento(id);
        }
    }
}
