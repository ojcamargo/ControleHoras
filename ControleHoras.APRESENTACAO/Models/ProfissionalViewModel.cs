using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ProfissionalViewModel : IValidatableObject
    {
        [Key]
        public int ProfissionalID { get; set; }

        [Required(ErrorMessage ="Informe o nome do profissional")]
        [MaxLength(50, ErrorMessage ="Tamanho máximo de {0} caracteres")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo de {0} caracteres")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Horário de entrada inválido")]
        [Display(Name = "Horário de entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? HorarioEntrada { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Horário de saída inválido")]
        [Display(Name = "Horário de saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? HorarioSaida { get; set; }

        [Display(Name = "Valor hora")]
        public decimal? ValorHora { get; set; }

        [Display(Name = "Valor Mensal")]
        public decimal? ValorMensal { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [Display(Name = "Modalidade de apuração")]
        public string ModalidadeApuracao { get; set; }

        [Display(Name = "Regime de Contratação")]
        public string Regime { get; set; }

        [Display(Name = "Início do período de férias")]
        public DateTime? FeriasInicio { get; set; }

        [Display(Name = "Fim do período de férias")]
        public DateTime? FeriasTermino { get; set; }

        public virtual ICollection<AlocacaoViewModel> Alocacao { get; set; }
        public virtual ICollection<ProfissionalDispositivoViewModel> Dispositivos { get; set; }
        public virtual UsuarioCriacaoViewModel Usuario { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HorarioSaida.HasValue && HorarioEntrada.HasValue)
            {
                if (HorarioSaida.Value < HorarioEntrada.Value)
                {
                    yield return new ValidationResult("Horário de saída não pode ser menor que horário de entrada", new[] { "HorarioSaida" });
                }
            }
            if (FeriasInicio.HasValue && FeriasTermino.HasValue)
            {
                if(FeriasTermino.Value < FeriasInicio.Value)
                {
                    yield return new ValidationResult("Data de término de férias não pode ser menor que a data de início ", new[] { "FeriasInicio" });
                }
            }
        }
    }
}