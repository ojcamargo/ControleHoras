using System;
using System.Collections.Generic;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Services
{
    public class ContratoService : BaseService<Contrato>, IContratoService
    {
        private readonly IContratoRepository _repository;

        public ContratoService(IContratoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override void Incluir(Contrato objeto)
        {
            objeto.Ativo = true;
            base.Incluir(objeto);
        }

        public void Desativar(Contrato objeto)
        {
            objeto.Ativo = false;
            _repository.Atualizar(objeto);
        }

        public void Reativar(Contrato objeto)
        {
            objeto.Ativo = true;
            _repository.Atualizar(objeto);
        }

        public ICollection<Contrato> ListarAtivos()
        {
            return _repository.ListarAtivos();
        }

        public Contrato ConsultarPorIdSemRastreamento(long id)
        {
            return _repository.ConsultarPorIdSemRastreamento(id);
        }



    }
}
