using System.Collections.Generic;

namespace ControleHoras.DATA.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Incluir(TEntity objeto);
        void Atualizar(TEntity objeto);
        void Remover(TEntity objeto);
        TEntity ConsultarPorId(long id);
        ICollection<TEntity> Listar();
        void Dispose();
    }
}
