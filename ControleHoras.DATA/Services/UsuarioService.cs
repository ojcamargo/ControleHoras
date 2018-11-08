using System;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _service;

        public UsuarioService(IUsuarioRepository service)
            : base(service)
        {
            _service = service;
        }

        public new void Atualizar(Usuario objeto)
        {
            Usuario valoresOriginais = null;
            try
            {
                valoresOriginais = this.ConsultarPorIdSemRastreamento(objeto.UsuarioID);
                objeto.Senha = valoresOriginais.Senha;
                base.Atualizar(objeto);
            }
            finally
            {
                valoresOriginais = null;
            }
        }

        public Usuario ValidarUsuario(string login)
        {
            return _service.ValidarUsuario(login);
        }

        public Usuario ValidarUsuario(string login, string senha)
        {
            return _service.ValidarUsuario(login, senha);
        }

        public Usuario ConsultarPorIdSemRastreamento(long id)
        {
            return _service.ConsultarPorIdSemRastreamento(id);
        }

        
    }
}
