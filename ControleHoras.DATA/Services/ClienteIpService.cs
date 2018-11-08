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
    public class ClienteIpService : BaseService<ClienteIp>, IClienteIpService
    {
        private readonly IClienteIpRepository _repository;
        public ClienteIpService(IClienteIpRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
        
    }
}
