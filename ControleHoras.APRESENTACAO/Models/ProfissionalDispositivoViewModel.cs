using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ProfissionalDispositivoViewModel
    {
        [Key]
        public int ProfissionalDispositivoID { get; set; }

        [Required(ErrorMessage = "Informe o profissional")]
        [Display(Name = "Profissional")]
        public int ProfissionalID { get; set; }

        [Required(ErrorMessage = "Informe o profissional")]
        [MaxLength(20,ErrorMessage ="Tamanho máximo de {1} caracteres")]
        [MinLength(15, ErrorMessage = "Tamanho mínimo de {1} caracteres")]
        [Display(Name = "IMEI")]
        public string Imei { get; set; }

        [RegularExpression(@"^\([0-9]{2}\)[9][0-9]{4}\-[0-9]{4}$", ErrorMessage = "Telefone inválido")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo de {1} caracteres")]
        [MinLength(11, ErrorMessage = "Tamanho mínimo de {1} caracteres")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public virtual ProfissionalViewModel Profissional { get; set; }

        public SelectList ListaProfissionaisAtivos { get; set; }
    }
}