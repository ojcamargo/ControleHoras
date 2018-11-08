using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class HorasExtrasViewModel
    {
        [Key]
        public int AprovacaoID { get; set; }

        [Required(ErrorMessage ="Informe o profissional")]
        [Display(Name ="Profissional")]
        public int ProfissionalID { get; set; }

        [Required(ErrorMessage = "Informe o contrato")]
        [Display(Name = "Contrato")]
        public int ContratoID { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data inicial inválida")]
        [Display(Name ="Data Inicial")]
        public DateTime DataInicial { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Data final inválida")]
        [Display(Name = "Data Final")]
        public DateTime DataFinal { get; set; }
        public bool Pendente { get; set; }

        public virtual ProfissionalViewModel Profissional { get; set; }
        public virtual ContratoViewModel Contrato { get; set; }

        public SelectList ListaProfissionais { get; set; }
        public SelectList ListaContratos { get; set; }
    }
}