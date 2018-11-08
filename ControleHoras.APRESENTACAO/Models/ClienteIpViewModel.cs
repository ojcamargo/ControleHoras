using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ControleHoras.DATA.Context;

namespace ControleHoras.APRESENTACAO.Models
{
    public class ClienteIpViewModel
    {
        [Key]
        public int ClienteIpID { get; set; }

        [Required(ErrorMessage = "Informe o cliente")]
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Informe o IP")]
        [RegularExpression(@"^(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))$", ErrorMessage="IP Inválido")]
        [Display(Name = "IP")]
        public string Ip { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }


        public SelectList ListaClientesAtivos { get; set; }
    }
}