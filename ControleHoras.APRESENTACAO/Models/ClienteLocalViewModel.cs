using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ClienteLocalViewModel
    {
        [Key]
        public int LocalID { get; set; }

        [Required(ErrorMessage = "Informe o cliente")]
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Número")]
        public string NumeroLogradouro { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        [StringLength(2, ErrorMessage = "Tamanho de {0} caracteres")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [StringLength(9, ErrorMessage = "Tamanho de {0} caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente números")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\,0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\,[0-9]{1,6})?))$", ErrorMessage = "Valor inválido para latitude")]
        [Display(Name = "Logitude")]
        public double Longitude { get; set; }

        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\,0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\,[0-9]{1,6})?))$", ErrorMessage = "Valor inválido para longitude")]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        public SelectList ListaClientesAtivos { get; set; }
    }
}