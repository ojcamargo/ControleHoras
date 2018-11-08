using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "Informe o nome do cliente")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo de {0} caracteres")]
        [Display(Name = "Nome Fantasia")]
        public string Nome { get; set; }
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        [StringLength(14, ErrorMessage = "Tamanho de {0} caracteres")]
        
        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente números")]
        [Display(Name = "CNPJ")]        
        public string CNPJ { get; set; }
        public virtual ICollection<ContratoViewModel> Contrato { get; set; }
        public virtual ICollection<ClienteIpViewModel> ClienteIp { get; set; }
        public virtual ICollection<ClienteLocalViewModel> ClienteLocal { get; set; }
        public virtual ICollection<UsuarioCriacaoViewModel> Usuario { get; set; }
    }
}