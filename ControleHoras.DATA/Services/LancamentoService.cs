using System;
using ControleHoras.DATA.Context;
using ControleHoras.DATA.Interfaces;
using System.Collections.Generic;
using ControleHoras.DATA.Repositories;

namespace ControleHoras.DATA.Services
{
    public class LancamentoService : BaseService<Lancamento>, ILancamentoService
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoService(ILancamentoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Lancamento ConsultarUltimoLancamento(int contratoId, int profissionalId)
        {
            var lancamento = _repository.ConsultarUltimoLancamento(contratoId, profissionalId);
            if(lancamento != null)
            {
                lancamento.PermitirEntrada = this.PermitirEntrada(lancamento);
                lancamento.PermitirSaida = this.PermitirSaida(lancamento);
            }
            return lancamento;
        }

        private bool PermitirEntrada(Lancamento ultimoLancamento)
        {
            if (ultimoLancamento == null)
                return true;
            else if (ultimoLancamento != null && ultimoLancamento.HorarioEntrada != null && ultimoLancamento.HorarioSaida != null)
                return true;
            else
                return false;
        }

        private bool PermitirSaida(Lancamento ultimoLancamento)
        {
            if (ultimoLancamento == null)
                return true;
            else if (ultimoLancamento != null && ultimoLancamento.HorarioEntrada != null 
                && ultimoLancamento.HorarioSaida == null)
                return true;
            else
                return false;
        }

        public void Entrada(Lancamento model)
        {
            Profissional profissional = null;
            using (ProfissionalRepository profissionalRepository = new ProfissionalRepository())
                profissional = profissionalRepository.ConsultarPorIdSemRastreamento(model.ProfissionalID);

            var lancamento = _repository.ConsultarUltimoLancamento(model.ContratoID, model.ProfissionalID);
            //Verifica se foi feito lançamento da saida no período anterior
            if (PermitirEntrada(lancamento))
            {
                var dominio = new Lancamento();
                dominio.ContratoID = model.ContratoID;
                dominio.ProfissionalID = model.ProfissionalID;
                dominio.Observacao = model.Observacao;
                dominio.HorarioEntrada = DateTime.Now;

                DateTime? horarioEntrada = dominio.HorarioEntrada;                
                //Verifica se o profissional entra nas regras de lançamento para CLT
                if (profissional.Regime.Equals("CLT"))
                {
                    //Resgatar horario de entrada do profissional
                    DateTime? horarioAtual = new DateTime(DateTime.Now.Year, 
                        DateTime.Now.Month, 
                        DateTime.Now.Day, 
                        profissional.HorarioEntrada.Value.Hours, 
                        profissional.HorarioEntrada.Value.Minutes, 
                        0);
                    //Verifica se o profissional esta dentro do horário de entrada
                    double tempoDecorrido = (horarioAtual - horarioEntrada).Value.TotalMinutes;
                    //Não permitir o lançamento após 15 minutos de tolerância
                    if (tempoDecorrido > 15)
                        throw new Exception("Entrada não permitida. Ultrapassado tempo limite.");

                    //Verificar se o profissional esta em período de férias
                    if(profissional.FeriasInicio.HasValue && profissional.FeriasTermino.HasValue)
                    {
                        if(horarioEntrada.Value >= profissional.FeriasInicio.Value &&
                            horarioEntrada.Value <= profissional.FeriasTermino.Value)
                        {
                            throw new Exception("Entrada não permitida no período de férias.");
                        }
                    }
                }

                dominio.HorarioSaida = null;
                dominio.Atividade = "";
                _repository.Incluir(dominio);

            }
            else
            {
                throw new Exception("Entrada não permitida");
            }
        }

        public void Saida(Lancamento model)
        {
            if(string.IsNullOrEmpty(model.Atividade))
                throw new Exception("Atividade não foi informada");
            var lancamento = _repository.ConsultarUltimoLancamento(model.ContratoID, model.ProfissionalID);

            //Todo lancamento por padrao não requer análise prévai
            //Desta forma o mesmo, não pode ser marcado como pendente
            lancamento.Pendente = false;
            if (!PermitirEntrada(lancamento))
            {
                if (model.HorarioSaida.HasValue) //lancamento retroativo
                {
                    //Quando for um lançamento retroativo, marcar como pendente, para que possa ser avaliado
                    lancamento.Pendente = true;
                    if (model.HorarioSaida.Value < lancamento.HorarioEntrada)
                        throw new Exception("Horário de entrada não pode ser menor que o horário de entrada");
                    else if (model.HorarioSaida.Value >= DateTime.Now)
                        throw new Exception("Horário de saída não pode ser maior do que o horário atual");
                    else
                        lancamento.HorarioSaida = model.HorarioSaida.Value; 
                }
                else
                    lancamento.HorarioSaida = DateTime.Now;
                lancamento.Atividade = model.Atividade;
                lancamento.Observacao = model.Observacao;
                _repository.Atualizar(lancamento);
            }
            else
            {
                throw new Exception("Saída não permitida");
            }
        }
        public ICollection<Lancamento> BuscarLancamentosProfissional(int profissionalId)
        {
            return _repository.BuscarLancamentosProfissional(profissionalId);
        }

        /// <summary>
        /// Editar lançamento
        /// </summary>
        /// <param name="info"></param>
        public new void Atualizar(Lancamento info)
        {
            Lancamento lancamento = _repository.ConsultarPorId(info.LancamentoID);
            if(lancamento != null)
            {
                lancamento.HorarioEntrada = info.HorarioEntrada;
                lancamento.HorarioSaida = info.HorarioSaida;
                _repository.Atualizar(lancamento);
            }
        }

        /// <summary>
        /// Excluir lancamento
        /// </summary>
        /// <param name="lancamentoId"></param>
        public void Remover(int lancamentoId)
        {
            Lancamento lancamento = _repository.ConsultarPorId(lancamentoId);
            if (lancamento != null)
            {
                _repository.Remover(lancamento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lancamentoId"></param>
        /// <param name="userId"></param>
        public void Aprovar(long lancamentoId)
        {
            Lancamento lancamento = _repository.ConsultarPorId(lancamentoId);
            if (lancamento != null)
            {
                lancamento.Pendente = false;
                _repository.Atualizar(lancamento);
            }
        }

    }
}
