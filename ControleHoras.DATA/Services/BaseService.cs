using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Services
{
    public class BaseService<TEntidade> : IDisposable, IBaseService<TEntidade> where TEntidade : class
    {
        private readonly IBaseRepository<TEntidade> _repositorio;

        public BaseService(IBaseRepository<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual void Incluir(TEntidade objeto)
        {
            _repositorio.Incluir(objeto);
        }

        public virtual void Atualizar(TEntidade objeto)
        {
            _repositorio.Atualizar(objeto);
        }

        public virtual void Remover(TEntidade objeto)
        {
            _repositorio.Remover(objeto);
        }

        public virtual TEntidade ConsultarPorId(long id)
        {
            return _repositorio.ConsultarPorId(id);
        }

        public virtual ICollection<TEntidade> Listar()
        {
            return _repositorio.Listar();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
