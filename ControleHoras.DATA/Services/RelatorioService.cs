using ControleHoras.DATA.Context.Custom;
using ControleHoras.DATA.Interfaces;
using System;
using System.Collections.Generic;

namespace ControleHoras.DATA.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IClienteRepository _clienteRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository, 
            IProfissionalRepository profissionalRepository, 
            IClienteRepository clienteRepository)
        {
            _relatorioRepository = relatorioRepository;
            _profissionalRepository = profissionalRepository;
            _clienteRepository = clienteRepository;
        }

        public RelatorioHoras ConsultarLancamentos(int profissionalID, DateTime dataInicial, DateTime dataFinal)
        {
            RelatorioHoras relatorio = new RelatorioHoras();
            relatorio.DataEmissao = DateTime.Now;
            relatorio.Periodo = string.Format("De {0} à {1}", dataInicial.ToString("dd/MM/yyyy"), dataFinal.ToString("dd/MM/yyyy"));
            var profissional = _profissionalRepository.ConsultarPorIdSemRastreamento(profissionalID);
            if (profissional != null)
                relatorio.Profissional = profissional.Nome;
            relatorio.Lancamentos = _relatorioRepository.ConsultarLancamentos(profissionalID, dataInicial, dataFinal);
            return relatorio;
        }
        
        public RelatorioFaturamento ConsultarFaturamento(int clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            RelatorioFaturamento relatorio = new RelatorioFaturamento();
            relatorio.DataEmissao = DateTime.Now;
            relatorio.Periodo = string.Format("De {0} à {1}", dataInicial.ToString("dd/MM/yyyy"), dataFinal.ToString("dd/MM/yyyy"));
            var cliente = _clienteRepository.ConsultarPorIdSemRastreamento(clienteId);
            if (cliente != null)
                relatorio.Cliente = cliente.Nome;
            relatorio.Lancamentos = _relatorioRepository.ConsultarFaturamento(clienteId, dataInicial, dataFinal);
            return relatorio;
        }

        public ICollection<AcompanhamentoDiario> ConsultarLancamentosDiarios(int? clienteId, int? contratoId, int? profissionalId, int? situacaoId)
        {
            return _relatorioRepository.ConsultarLancamentosDiarios(clienteId, contratoId, profissionalId, situacaoId);
        }
    }
}
