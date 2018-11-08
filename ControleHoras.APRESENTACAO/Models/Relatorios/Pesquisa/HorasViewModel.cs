using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models.Relatorios.Pesquisa
{
    /// <summary>
    /// Filtros de pesquisa do relatório de horas
    /// </summary>
    public class HorasViewModel
    {
        [Display(Name = "Profissional")]
        [Required(ErrorMessage = "Informe o profissional")]
        public int ProfissionalID { get; set; }
        public SelectList Profissionais { get; set; }

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
            if (ProfissionalID <= 0)
            {
                yield return new ValidationResult("Data inicial não pode ser maior que data final", new[] { "ProfissionalID" });
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