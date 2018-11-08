using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    /// <summary>
    /// Model generica para outras views do cadastro de usuários
    /// </summary>
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioID { get; set; }
        [Required(ErrorMessage =@"Informe o login")]
        [Display(Name ="Login")]
        public string Login { get; set; }

        [Display(Name = "Cliente")]
        public int? ClienteID { get; set; }

        [Display(Name = "Profissional")]
        public int? ProfissionalID { get; set; }

        [Display(Name = "Administrativo")]
        public bool Adm { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual ProfissionalViewModel Profissional { get; set; }

        public SelectList ListaClientes { get; set; }
        public SelectList ListaProfissionais { get; set; }
        
    }
}