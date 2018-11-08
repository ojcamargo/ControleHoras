using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public interface IAutoMapper<TView, TDomain>
        where TView : class
        where TDomain : class
    {
        ICollection<TView> Mapear(ICollection<TDomain> dados);
        TView Mapear(TDomain dados);

        ICollection<TDomain> Mapear(ICollection<TView> dados);

        TDomain Mapear(TView dados);
    }
}
