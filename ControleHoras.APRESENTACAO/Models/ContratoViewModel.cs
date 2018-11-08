using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ContratoViewModel : IValidatableObject
    {

        public ContratoViewModel()
        {

        }

        [Key]
        public int ContratoID { get; set; }
        [Required(ErrorMessage = "Informe o cliente")]
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Informe o número de contrato ou proposta")]
        [Display(Name = "Contrato/Proposta")]
        public string NumeroReferencia { get; set; }

        [Required(ErrorMessage = "Informe a modalidade de contrato")]
        [Display(Name = "Modalidade de contrato")]
        public string ModalidadeContrato { get; set; }

        [Required(ErrorMessage = "Informe a modalidade de apuração de horas")]
        [Display(Name = "Modalidade de apuração")]
        public string ModalidadeApuracao { get; set; }

        [Range(0, 200, ErrorMessage = "Valor deve estar entre {1} e {2}")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente números")]
        [Display(Name = "Quantidade horas/mês")]
        public int? QtdHorasMes { get; set; }

        [Display(Name = "Apuração de horas extras")]
        public bool ApuracaoHoraExtra { get; set; }

        [DataType(DataType.Currency, ErrorMessage ="Valor de hora extra inválido")]
        [Range(0, 100, ErrorMessage = "Valor deve estar entre {1} e {2}")]
        [Display(Name = "Valor hora extra")]
        public decimal? ValorHoraExtra { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataCadastro { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de início inválida")]
        [Display(Name = "Ínicio do contrato")]
        public DateTime? DataInicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data final inválida")]
        [Display(Name = "Fim do contrato")]
        public DateTime? DataFim { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Detalhes do contrato")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [DataType(DataType.Currency, ErrorMessage ="Valor hora inválido")]
        [Range(0, 100, ErrorMessage = "Valor deve estar entre {0} e {1}")]
        [Display(Name = "Valor hora")]
        public decimal? ValorHora { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Horário de entrada inválido")]
        [Display(Name ="Horário de entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? HorarioEntrada { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Horário de saída inválido")]
        [Display(Name = "Horário de saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? HorarioSaida { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Intervalo de entrada inválido")]
        [Display(Name = "Horário de início do intervalo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? IntervaloInicio { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Intervalo de saída inválido")]
        [Display(Name = "Horário final do intervalo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? IntervaloFim { get; set; }

        [Display(Name = "Validar local de apontamento de horas")]
        public bool ValidarLocalizacao { get; set; }
        public virtual ICollection<AlocacaoViewModel> Alocacaos { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }

        public SelectList ListaClientesAtivos { get; set; }

        [Display(Name ="Profissionais")]
        public SelectList ListaProfissionais { get; set; }
        public IEnumerable<string> Profissionais { get; set; }
        public SelectList ListaProfissionaisAlocados { get; set; }
        public IEnumerable<string> ProfissionaisAlocados { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HorarioSaida.HasValue && HorarioEntrada.HasValue)
            {
                if (HorarioSaida.Value < HorarioEntrada.Value)
                {
                    yield return new ValidationResult("Horário de saída não pode ser menor que horário de entrada", new[] { "HorarioSaida" });
                }
            }
            if(DataInicio.HasValue && DataFim.HasValue)
            {
                if(DataFim.Value < DataInicio.Value)
                {
                    yield return new ValidationResult("Data final não pode ser menor que data de início", new[] { "DataFim" });
                }
            }
            

        }
    }
}