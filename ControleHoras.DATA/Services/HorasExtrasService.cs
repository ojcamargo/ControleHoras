using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;

namespace ControleHoras.DATA.Services
{
    public class HorasExtrasService : BaseService<HorasExtras>, IHorasExtrasService
    {
        private readonly IHorasExtrasRepository _repository;

        public HorasExtrasService(IHorasExtrasRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
        
    }
}
