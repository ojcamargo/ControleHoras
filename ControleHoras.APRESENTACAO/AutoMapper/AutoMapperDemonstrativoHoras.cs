using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControleHoras.APRESENTACAO.Models.Demonstrativos.Resultado;
using ControleHoras.DATA.Context.Custom;

namespace ControleHoras.APRESENTACAO.AutoMapper
{
    public class AutoMapperDemonstrativoHoras : IAutoMapper<HorasViewModel, DemonstrativoHoras>
    {

        private readonly AutoMapperDemonstrativoLancamentos _lancamentosMapper;
        private readonly AutoMapperProfissional _profissionalMapper;

        public AutoMapperDemonstrativoHoras()
        {
            _lancamentosMapper = new AutoMapperDemonstrativoLancamentos();
            _profissionalMapper = new AutoMapperProfissional();
        }

        public ICollection<DemonstrativoHoras> Mapear(ICollection<HorasViewModel> dados)
        {
            Collection<DemonstrativoHoras> lista = new Collection<DemonstrativoHoras>();
            foreach (HorasViewModel source in dados)
            {
                DemonstrativoHoras destination = new DemonstrativoHoras();
                destination.Data = source.Data;
                destination.Periodo = source.Periodo;
                destination.ValorTotal = source.ValorTotal;
                destination.ProfissionalID = source.ProfissionalID;
                if (source.Profissional != null)
                    destination.Profissional = _profissionalMapper.Mapear(source.Profissional);
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

        public DemonstrativoHoras Mapear(HorasViewModel dados)
        {
            DemonstrativoHoras destination = new DemonstrativoHoras();
            destination.Data = dados.Data;
            destination.Periodo = dados.Periodo;
            destination.ValorTotal = dados.ValorTotal;
            destination.ProfissionalID = dados.ProfissionalID;
            if (dados.Profissional != null)
                destination.Profissional = _profissionalMapper.Mapear(dados.Profissional);
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public HorasViewModel Mapear(DemonstrativoHoras dados)
        {
            HorasViewModel destination = new HorasViewModel();
            destination.Data = dados.Data;
            destination.Periodo = dados.Periodo;
            destination.ValorTotal = dados.ValorTotal;
            destination.ProfissionalID = dados.ProfissionalID;
            if (dados.Profissional != null)
                destination.Profissional = _profissionalMapper.Mapear(dados.Profissional);
            if (dados.Lancamentos != null && dados.Lancamentos.Count > 0)
                destination.Lancamentos = _lancamentosMapper.Mapear(dados.Lancamentos);
            return destination;
        }

        public ICollection<HorasViewModel> Mapear(ICollection<DemonstrativoHoras> dados)
        {
            ICollection<HorasViewModel> lista = new Collection<HorasViewModel>();
            foreach (DemonstrativoHoras source in dados)
            {
                HorasViewModel destination = new HorasViewModel();
                destination.Data = source.Data;
                destination.Periodo = source.Periodo;
                destination.ValorTotal = source.ValorTotal;
                destination.ProfissionalID = source.ProfissionalID;
                if (source.Profissional != null)
                    destination.Profissional = _profissionalMapper.Mapear(source.Profissional);
                if (source.Lancamentos != null && source.Lancamentos.Count > 0)
                    destination.Lancamentos = _lancamentosMapper.Mapear(source.Lancamentos);
                lista.Add(destination);
            }
            return lista;
        }

    }
}