using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace ControleHoras.DATA.Repositories
{
    public class BaseRepository<TEntidade> : IDisposable, IBaseRepository<TEntidade> where TEntidade : class
    {
        protected Entities Db = new Entities();

        public void Incluir(TEntidade objeto)
        {
            try
            {
                Db.Set<TEntidade>().Add(objeto);
                Db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string erro = "";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        erro += string.Format(" Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(erro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(TEntidade objeto)
        {
            try
            {
                Db.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string erro = "";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        erro += string.Format(" Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(erro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(TEntidade objeto)
        {
            try
            {
                Db.Set<TEntidade>().Remove(objeto);
                Db.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    if (sqlException.Errors.Count > 0)
                    {
                        switch (sqlException.Errors[0].Number)
                        {
                            case 547:
                                throw new Exception("Este registro possúi elementos dependentes e não pode ser excluído. Considere desativar o registro.");
                            default:
                                throw ex;
                        }
                    }
                }
                else
                    throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TEntidade ConsultarPorId(long id)
        {
            return Db.Set<TEntidade>().Find(id);
        }

        public ICollection<TEntidade> Listar()
        {
            return Db.Set<TEntidade>().ToList();
        }

        public void Dispose()
        {

        }
    }
}
