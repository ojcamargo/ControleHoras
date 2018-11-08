using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using ControleHoras.DATA.Repositories;
using ControleHoras.DATA.Services;

namespace ControleHoras.DATA.Services
{
    public class ProfissionalDispositivoService : BaseService<ProfissionalDispositivo>, IProfissionalDispositivoService
    {
        private readonly IProfissionalDispositivoRepository _repository;

        public ProfissionalDispositivoService(IProfissionalDispositivoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
