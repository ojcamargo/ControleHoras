using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;

namespace ControleHoras.DATA.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        /// <summary>
        /// Validar usuários somente por login (interno)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Usuario ValidarUsuario(string usuario);
        /// <summary>
        /// Validar usuario por login e senha (externo)
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Usuario ValidarUsuario(string usuario, string senha);
        /// <summary>
        /// Metodo utilizado apenas para consultar dados sem rastreamento para edicao de dados
        /// </summary>
        /// <param name="id">Código identificador do usuário</param>
        /// <remarks>Para consultar um registro que sera editado, utilizar metodo ConsultarPorId()</remarks>
        /// <returns></returns>
        Usuario ConsultarPorIdSemRastreamento(long id);
    }
}
