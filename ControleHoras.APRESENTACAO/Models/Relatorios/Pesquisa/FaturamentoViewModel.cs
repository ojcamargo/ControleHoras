using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Pesquisa
{
    /// <summary>
    /// Filtros de pesquisa para tela de apresentação do relatório de faturamento
    /// </summary>
    public class FaturamentoViewModel : IValidatableObject
    {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Informe o cliente")]
        public int ClienteID { get; set; }
        public SelectList Clientes { get; set; }

        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date, ErrorMessage = "Data inicial inválida")]
        [Required(ErrorMessage = "Informe a data inicial")]
        public DateTime? DataInicial { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date, ErrorMessage = "Data final inválida")]
        [Required(ErrorMessage = "Informe a data final")]
        public DateTime? DataFinal { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClienteID <= 0)
            {
                yield return new ValidationResult("Informe o cliente", new[] { "ProfissionalID" });
            }
            if (!DataInicial.HasValue)
            {
                yield return new ValidationResult("Informe a data inicial", new[] { "DataInicial" });
            }
            if (!DataFinal.HasValue)
            {
                yield return new ValidationResult("Informe a data inicial", new[] { "DataFinal" });
            }
            if (DataInicial.Value > DataFinal.Value)
            {
                yield return new ValidationResult("Data inicial não pode ser maior que data final", new[] { "DataInicial" });
            }
        }
    }
}