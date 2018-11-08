using ControleHoras.DATA.Context.Custom;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoras.DATA.Services
{
    public class DemonstrativoHorasService : IDemonstrativoHorasService
    {
        private readonly IDemonstrativoHorasRepository _demonstrativoRepository;
        private readonly IProfissionalRepository _profissionalRepository;

        public DemonstrativoHorasService(IDemonstrativoHorasRepository demonstrativoRepository, IProfissionalRepository profissionalRepository)
        {
            _demonstrativoRepository = demonstrativoRepository;
            _profissionalRepository = profissionalRepository;
        }

        public DemonstrativoHoras ConsultarDemonstrativo(int profissionalID)
        {
            DemonstrativoHoras demonstrativo = new DemonstrativoHoras();
            demonstrativo.Data = DateTime.Now;
            demonstrativo.Periodo = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1).ToString("MM/yyyy");
            demonstrativo.ProfissionalID = profissionalID;
            demonstrativo.Profissional = _profissionalRepository.ConsultarPorIdSemRastreamento(profissionalID);
            demonstrativo.Lancamentos = _demonstrativoRepository.ConsultarLancamentos(profissionalID);
            if (demonstrativo.Lancamentos != null && demonstrativo.Lancamentos.Count > 0)
            {
                foreach (DemonstrativoLancamentos lancamento in demonstrativo.Lancamentos)
                {
                    if (demonstrativo.Profissional.ModalidadeApuracao == "A")
                    {
                        lancamento.ValorBase = demonstrativo.Profissional.ValorHora.Value;
                        lancamento.ValorPorContrato = lancamento.ValorBase * lancamento.QtdHoras;
                    }
                    else
                    {
                        lancamento.ValorBase = demonstrativo.Profissional.ValorMensal.Value;
                        lancamento.ValorPorContrato = lancamento.ValorBase / lancamento.QtdDiasTrabalhados;
                    }

                    demonstrativo.ValorTotal += lancamento.ValorPorContrato;
                }

            }
            return demonstrativo;
        }
    }
}
