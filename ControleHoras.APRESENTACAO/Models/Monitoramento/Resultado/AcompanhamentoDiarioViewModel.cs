using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleHoras.APRESENTACAO.Models.Monitoramento.Resultado
{
    /// <summary>
    /// Acompanhamento diário do registro de entrada dos profissionais
    /// </summary>
    public class AcompanhamentoDiarioViewModel
    {
        /// <summary>
        /// Nome do profissional
        /// </summary>
        public string Profissional { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// Nome do contrato
        /// </summary>
        public string Contrato { get; set; }
        /// <summary>
        /// Situação do profissional
        /// </summary>
        /// <remarks>
        /// Presença registrada,
        /// Presença registrada com atraso, 
        /// Presença não registrada
        /// </remarks>
        public string Situacao { get; set; }
        /// <summary>
        /// Horário de entrada
        /// </summary>
        public string HoraEntrada { get; set; }
    }
}