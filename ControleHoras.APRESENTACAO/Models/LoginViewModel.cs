using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class LoginViewModel
    {
        

        public enum Dominio
        {
            [Display(Description = "Interno/Exchange")]
            Computecnica = 1,
            [Display(Description = "Externo/Cliente")]
            Externo = 2
        }

        private string ObterDescricaoEnum(Enum valor)
        {
            var tipoEnum = valor.GetType();
            if (!tipoEnum.IsEnum) throw new ArgumentException(String.Format("Tipo '{0}' não é Enum", tipoEnum));

            var listaItensSelecao = tipoEnum.GetMember(valor.ToString());
            if (listaItensSelecao.Length == 0) throw new ArgumentException(String.Format("Valor '{0}' não encontrado no tipo '{1}'", valor, tipoEnum.Name));

            var item = listaItensSelecao[0];
            var atributo = item.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
            if (atributo.Length == 0) throw new ArgumentException(String.Format("'{0}.{1}' não tem Display atribute", tipoEnum.Name, valor));

            var attribute = (System.ComponentModel.DataAnnotations.DisplayAttribute)atributo[0];
            return attribute.Description;
        }


        [Key]
        public int UsuarioID { get; set; }
        [Required(ErrorMessage = "Informe o login")]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage ="Informe o domínio")]
        [Display(Name = "Domínio")]
        public Dominio ModoAutenticacao { get; set; }

        public SelectList ListaDominios
        {
            get
            {
                var enumDataColours = from Dominio e in Enum.GetValues(typeof(Dominio))
                                      select new
                                      {
                                          ID = e.ToString(),
                                          Name = ObterDescricaoEnum((Dominio)e)
                                      };
                return new SelectList(enumDataColours, "ID", "Name");
            }
        }

    }
}