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
    public class ClienteLocalService : BaseService<ClienteLocal>, IClienteLocalService
    {
        private readonly IClienteLocalRepository _repository;
        public ClienteLocalService(IClienteLocalRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
