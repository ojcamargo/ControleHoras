using System;
using System.Collections.Generic;
using System.Linq;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        /// <summary>
        /// Validar usuario por login (interno)
        /// </summary>
        /// <param name="login">ID de usuário</param>
        /// <param name="senha">senha de acesso</param>
        /// <returns></returns>
        public Usuario ValidarUsuario(string login)
        {
            var usuario = Db.Usuario.Where(x => x.Login == login).FirstOrDefault();
            if (usuario != null && usuario.ProfissionalID.HasValue)
            {
                usuario.Profissional = Db.Profissional.Where(x => x.ProfissionalID == usuario.ProfissionalID).FirstOrDefault();
            }
            return usuario;
        }

        /// <summary>
        /// Validar usuario por login e senha (externo)
        /// </summary>
        /// <param name="login">ID de usuário</param>
        /// <param name="senha">senha de acesso</param>
        /// <returns></returns>
        public Usuario ValidarUsuario(string login, string senha)
        {
            var usuario = Db.Usuario.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
            if(usuario != null && usuario.ProfissionalID.HasValue)
            {
                usuario.Profissional = Db.Profissional.Where(x => x.ProfissionalID == usuario.ProfissionalID).FirstOrDefault();
            }
            return usuario;
        }

        

        /// <summary>
        /// Consultar usuario para edição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new Usuario ConsultarPorId(long id)
        {
            Usuario item = base.ConsultarPorId(id);
            if(item.ClienteID > 0)
                item.Cliente = Db.Cliente.Find(item.ClienteID);
            if(item.ProfissionalID > 0)
                item.Profissional = Db.Profissional.Find(item.ProfissionalID);
            return item;
        }

        /// <summary>
        /// Consultar usuario por id sem marcar registro para edicao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario ConsultarPorIdSemRastreamento(long id)
        {
            return Db.Usuario.AsNoTracking().Single(x => x.UsuarioID == id);
        }

        
    }
}
