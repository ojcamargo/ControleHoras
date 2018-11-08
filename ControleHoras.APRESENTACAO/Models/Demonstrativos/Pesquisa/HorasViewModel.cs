using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models.Demonstrativos.Pesquisa
{
    /// <summary>
    /// Filtros de pesquisa da interface de demonstrativo de horas
    /// </summary>
    public class HorasViewModel
    {
        [Display(Name = "Profissional")]
        [Required(ErrorMessage = "Informe o profissional")]
        public int ProfissionalID { get; set; }
        public SelectList Profissionais { get; set; }
    }
}