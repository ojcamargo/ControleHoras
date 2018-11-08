using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models.Monitoramento.Pesquisa
{
    /// <summary>
    /// Acompanhamento diário de entradas dos profissionais
    /// Filtros de pesquisa para consulta lançamentos
    /// </summary>
    public class AcompanhamentoDiarioViewModel
    {
        /// <summary>
        /// ID do cliente selecionado
        /// </summary>
        [Display(Name ="Cliente")]
        public int? ClienteID { get; set; }
        /// <summary>
        /// Lista de clientes
        /// </summary>
        public SelectList Clientes { get; set; }
        /// <summary>
        /// ID do profissional selecionado
        /// </summary>
        [Display(Name = "Profissional")]
        public int? ProfissionalID { get; set; }
        /// <summary>
        /// Lista de profissionais
        /// </summary>
        public SelectList Profissionais { get; set; }
        /// <summary>
        /// ID do contrato selecionado
        /// </summary>
        [Display(Name = "Contrato")]
        public int? ContratoID { get; set; }
        /// <summary>
        /// Lista de contratos
        /// </summary>
        public SelectList Contratos { get; set; }
        /// <summary>
        /// Situação do profissional
        /// </summary>
        [Display(Name = "Situação")]
        public int? SituacaoID { get; set; }
        /// <summary>
        /// Lista de situações possíveis
        /// </summary>
        /// <remarks>
        /// Presença registrada,
        /// Presença registrada com atraso, 
        /// Presença não registrada
        /// </remarks>
        public SelectList Situacao { get; set; }
    }
}