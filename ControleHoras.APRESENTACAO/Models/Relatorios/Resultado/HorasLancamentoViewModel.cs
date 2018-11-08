using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Resultado
{
    /// <summary>
    /// Lançamentos do relatório de horas
    /// </summary>
    public class HorasLancamentoViewModel
    {
        public string Contrato { get; set; }
        public string Cliente { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string Atividade { get; set; }

        public string DataEntrada
        {
            get
            {
                if (Entrada.HasValue)
                    return Entrada.Value.ToString("dd/MM/yyyy");
                else
                    return "";
            }
        }

        public string HoraEntrada
        {
            get
            {
                if (Entrada.HasValue)
                    return Entrada.Value.ToString("HH:mm");
                else
                    return "";
            }
        }

        public string DataSaida
        {
            get
            {
                if (Saida.HasValue)
                    return Saida.Value.ToString("dd/MM/yyyy");
                else
                    return "";
            }
        }

        public string HoraSaida
        {
            get
            {
                if (Saida.HasValue)
                    return Saida.Value.ToString("HH:mm");
                else
                    return "";
            }
        }
    }
}