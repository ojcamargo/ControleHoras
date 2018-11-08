using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    /// <summary>
    /// Model exclusiva para view de edição de senha
    /// Somente senha obrigatório
    /// </summary>
    public class UsuarioSenhaViewModel : IValidatableObject
    {
        [Key]
        public int UsuarioID { get; set; }
        
        [Display(Name ="Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = @"Informe a senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = @"Digite a senha novamente")]
        [Display(Name = "Confirmação de Senha")]
        public string ConfirmarSenha { get; set; }

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Senha.Equals(ConfirmarSenha))
            {
                yield return new ValidationResult("Senhas não conferem", new[] { "ConfirmarSenha" });
            }
            if(ClienteID > 0 && ProfissionalID > 0)
            {
                yield return new ValidationResult("Usuário não pode ser associado a um profissional e um cliente.", new[] { "ClienteID", "ProfissionalID" });
            }
        }
    }
}