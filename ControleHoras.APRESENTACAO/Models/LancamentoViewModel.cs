using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class LancamentoViewModel
    {
        [Key]
        public long LancamentoID { get; set; }

        [Required(ErrorMessage = "Informe o contrato")]
        [Display(Name = "Contrato/Proposta")]
        public int ContratoID { get; set; }

        [Required(ErrorMessage = "Informe o profissional")]
        [Display(Name = "Profissional")]
        public int ProfissionalID { get; set; }

        [Display(Name = "Horário de entrada")]
        [DataType(DataType.DateTime, ErrorMessage = "Data/Horário de entrada inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? HorarioEntrada { get; set; }

        [Display(Name = "Horário de saída")]
        [DataType(DataType.DateTime, ErrorMessage = "Data/Horário de entrada inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? HorarioSaida { get; set; }

        [Required(ErrorMessage = "Informe a atividade")]
        [MaxLength(50, ErrorMessage = @"Tamanho máximo de {0} caracteres")]
        [Display(Name = "Atividade")]
        public string Atividade { get; set; }
        [Display(Name = "Validar local para apontamento de horas")]

        public bool? LocalValidado { get; set; }

        public bool PermitirEntrada { get; set; }
        public bool PermitirSaida { get; set; }

        public virtual ProfissionalViewModel Profissional { get; set; }
        public virtual ContratoViewModel Contrato { get; set; }

        public SelectList Contratos { get; set; }

        [Display(Name = "Observações")]
        public String Observacao { get; set; }
    }

    public class LancamentoEdicaoViewModel
    {
        [Key]
        public long LancamentoID { get; set; }

        [Display(Name = "Horário de entrada")]
        [DataType(DataType.DateTime, ErrorMessage = "Data/Horário de entrada inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "Informe o horário de entrada")]
        public DateTime? HorarioEntrada { get; set; }

        [Display(Name = "Horário de saída")]
        [DataType(DataType.DateTime, ErrorMessage = "Data/Horário de entrada inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "Informe o horário de saída")]
        public DateTime? HorarioSaida { get; set; }

        public bool Pendente { get; set; }
        public string Atividade { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public string Contrato { get; set; }

    }

    public class LancamentoPesquisaViewModel
    {
        [Display(Name ="Profissional")]
        public int ProfissionalID { get; set; }
        public SelectList Profissionais { get; set; }
        public ICollection<LancamentoEdicaoViewModel> Lancamentos { get; set; }
    }
}